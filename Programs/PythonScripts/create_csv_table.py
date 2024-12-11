import struct
import csv
import sys
import os

def process_binary_files(file1, file2, output_csv, scale_range=(-255, 255)):
    """
    İkili dosyaları bellekte tutmadan işleyip, CSV dosyasına yazar.

    Args:
        file1 (str): İlk dosya yolu (TX1 için).
        file2 (str): İkinci dosya yolu (TX2 için).
        output_csv (str): Çıkış CSV dosyası yolu.
        scale_range (tuple): (-min_value, max_value) ölçek aralığı.
    """
    min_val, max_val = scale_range
    scale_factor = max_val / (2**15 - 1)  # 16-bit -> -32,768 ile 32,767 arasında ölçekleme

    # Dosyaları satır satır işleyerek CSV'ye yaz
    with open(file1, "rb") as f1, open(file2, "rb") as f2, open(output_csv, mode="w", newline="") as csvfile:
        writer = csv.writer(csvfile)

        while True:
            # TX1 ve TX2 için örnekleri oku
            sample1 = f1.read(4)  # TX1 için bir örnek (2 byte I, 2 byte Q)
            sample2 = f2.read(4)  # TX2 için bir örnek (2 byte I, 2 byte Q)

            if not sample1 or not sample2:
                break  # Eğer herhangi bir dosyada veri biterse işlemi durdur

            # TX1 ve TX2 verilerini çöz
            i1, q1 = struct.unpack("hh", sample1)
            i2, q2 = struct.unpack("hh", sample2)

            # Ölçekleme ve sınırlandırma
            i1 = max(min(int(i1 * scale_factor), max_val), min_val)
            q1 = max(min(int(q1 * scale_factor), max_val), min_val)
            i2 = max(min(int(i2 * scale_factor), max_val), min_val)
            q2 = max(min(int(q2 * scale_factor), max_val), min_val)

            # Veriyi CSV dosyasına yaz
            writer.writerow([i1, q1, i2, q2])

    print(f"CSV dosyası '{output_csv}' oluşturuldu.")

# Komut satırından dosya yollarını al
if __name__ == "__main__":
    if len(sys.argv) != 4:
        print("Hatalı giriş! Lütfen üç parametre giriniz: <TX1 bin dosya yolu> <TX2 bin dosya yolu> <output.csv dosya yolu>")
        sys.exit(1)

    binary_file1 = sys.argv[1]  # İlk dosya yolu (TX1 için)
    binary_file2 = sys.argv[2]  # İkinci dosya yolu (TX2 için)
    output_csv_file = sys.argv[3]  # Çıkış CSV dosyası yolu

    try:
        if not os.path.exists(binary_file1) or not os.path.exists(binary_file2):
            print("Hata: Dosyalardan biri veya her ikisi de bulunamadı.")
            sys.exit(1)

        process_binary_files(binary_file1, binary_file2, output_csv_file)

    except FileNotFoundError as e:
        print(f"Hata: Dosya bulunamadı - {e}")
    except Exception as e:
        print(f"Beklenmedik hata: {e}")
