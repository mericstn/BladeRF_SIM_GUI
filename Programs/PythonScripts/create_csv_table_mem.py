import struct
import csv
import sys
import os

def read_binary_file(file_path, scale_range=(-255, 255)):
    """
    İkili dosyadan SC16 Q11 formatındaki verileri okur ve belirtilen aralığa ölçekler.
    
    Args:
        file_path (str): İkili dosya yolu.
        scale_range (tuple): (-min_value, max_value) ölçek aralığı.
    
    Returns:
        list of tuples: [(I1, Q1), (I2, Q2), ...]
    """
    iq_data = []
    min_val, max_val = scale_range
    scale_factor = max_val / (2**15 - 1)  # 16-bit -> -32,768 ile 32,767 arasında
    
    with open(file_path, "rb") as f:
        while True:
            sample = f.read(4)  # Her örnek 2 byte I ve 2 byte Q içerir
            if not sample:
                break
            i, q = struct.unpack("hh", sample)  # 16-bit signed integer format
            i_scaled = int(i * scale_factor)
            q_scaled = int(q * scale_factor)
            # Değerleri sınırlandır
            i_clamped = max(min(i_scaled, max_val), min_val)
            q_clamped = max(min(q_scaled, max_val), min_val)
            iq_data.append((i_clamped, q_clamped))
    return iq_data

def create_csv_for_mimo(file1, file2, output_csv):
    """
    İki dosyadan ölçeklenmiş I ve Q verilerini okuyarak BladeRF için uygun CSV formatını oluşturur.
    
    Args:
        file1 (str): İlk dosya (TX1 için).
        file2 (str): İkinci dosya (TX2 için).
        output_csv (str): Çıkış CSV dosyası yolu.
    """
    iq_data_tx1 = read_binary_file(file1, scale_range=(-255, 255))
    iq_data_tx2 = read_binary_file(file2, scale_range=(-255, 255))
    
    # Dosya boyutlarının eşit olduğundan emin olun
    min_length = min(len(iq_data_tx1), len(iq_data_tx2))
    iq_data_tx1 = iq_data_tx1[:min_length]
    iq_data_tx2 = iq_data_tx2[:min_length]
    
    # CSV dosyasını oluştur ve verileri yaz
    with open(output_csv, mode="w", newline="") as csvfile:
        writer = csv.writer(csvfile)
        
        # Başlık satırı (TX1 ve TX2 sütunları için)
        #writer.writerow(["TX1_I", "TX1_Q", "TX2_I", "TX2_Q"]) 
        
        # TX1 ve TX2 verilerini yaz
        for tx1, tx2 in zip(iq_data_tx1, iq_data_tx2):
            writer.writerow([tx1[0], tx1[1], tx2[0], tx2[1]])

    print(f"CSV dosyası '{output_csv}' oluşturuldu.")

# Komut satırından dosya yollarını al
if __name__ == "__main__":
    if len(sys.argv) != 4:
        print("Hatalı giriş! Lütfen üç parametre giriniz: <TX1 bin dosya yolu> <TX2 bin dosya yolu> <output.csv dosya yolu>")
        sys.exit(1)

    binary_file1 = sys.argv[1]  # İlk dosya yolu (TX1 için)
    binary_file2 = sys.argv[2]  # İkinci dosya yolu (TX2 için)
    output_csv_file = sys.argv[3]  # Çıkış CSV dosyası yolu

    # Dosyaların varlığını kontrol et
    try:
        if not os.path.exists(binary_file1) or not os.path.exists(binary_file2):
            print("Hata: Dosyalardan biri veya her ikisi de bulunamadı.")
            sys.exit(1)

        create_csv_for_mimo(binary_file1, binary_file2, output_csv_file)

    except FileNotFoundError as e:
        print(f"Hata: Dosya bulunamadı - {e}")
    except Exception as e:
        print(f"Beklenmedik hata: {e}")
