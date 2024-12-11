import struct
import csv
import sys

def read_binary_file(file_path, resolution=8):
    """
    İkili dosyadan SC16 Q11 formatındaki verileri okur ve belirlenen çözünürlüğe indirger.
    
    Args:
        file_path (str): İkili dosya yolu.
        resolution (int): Çıktı çözünürlüğü (ör: 8-bit).
    
    Returns:
        list of tuples: [(I1, Q1), (I2, Q2), ...]
    """
    iq_data = []
    scale_factor = (2 ** (resolution - 1)) / (2 ** 15)  # 16-bit'ten 8-bit'e ölçekleme
    
    with open(file_path, "rb") as f:
        while True:
            sample = f.read(4)  # Her örnek 2 byte I ve 2 byte Q içerir
            if not sample:
                break
            i, q = struct.unpack("hh", sample)  # 16-bit signed integer format
            i_scaled = int(i * scale_factor)
            q_scaled = int(q * scale_factor)
            iq_data.append((i_scaled, q_scaled))
    return iq_data

def create_csv_from_files(file1, file2, output_csv):
    """
    İki dosyadan 8-bit çözünürlükte I ve Q verilerini okuyarak CSV oluşturur.
    
    Args:
        file1 (str): İlk dosya (TX1 için).
        file2 (str): İkinci dosya (TX2 için).
        output_csv (str): Çıkış CSV dosyası yolu.
    """
    iq_data_tx1 = read_binary_file(file1, resolution=8)
    iq_data_tx2 = read_binary_file(file2, resolution=8)
    
    # Dosya boyutlarının eşit olduğundan emin olun
    min_length = min(len(iq_data_tx1), len(iq_data_tx2))
    iq_data_tx1 = iq_data_tx1[:min_length]
    iq_data_tx2 = iq_data_tx2[:min_length]
    
    # CSV dosyasını oluştur ve verileri yaz
    with open(output_csv, mode="w", newline="") as csvfile:
        writer = csv.writer(csvfile)
        writer.writerow(["TX1_I", "TX1_Q", "TX2_I", "TX2_Q"])  # Başlık
        for tx1, tx2 in zip(iq_data_tx1, iq_data_tx2):
            writer.writerow([tx1[0], tx1[1], tx2[0], tx2[1]])
    
    print(f"CSV dosyası '{output_csv}' oluşturuldu.")

# Komut satırından dosya yollarını al
if __name__ == "__main__":
    if len(sys.argv) != 4:
        print("Hatalı giriş! Lütfen üç parametre giriniz: <galsim.bin dosya yolu> <gpssim.bin dosya yolu> <output.csv dosya yolu>")
        sys.exit(1)

    binary_file1 = sys.argv[1]  # İlk dosya yolu (TX1 için)
    binary_file2 = sys.argv[2]  # İkinci dosya yolu (TX2 için)
    output_csv_file = sys.argv[3]  # Çıkış CSV dosyası yolu
    
    # Dosyaların varlığını kontrol et
    try:
        create_csv_from_files(binary_file1, binary_file2, output_csv_file)
    except FileNotFoundError as e:
        print(f"Hata: Dosya bulunamadı - {e}")
    except Exception as e:
        print(f"Beklenmedik hata: {e}")
