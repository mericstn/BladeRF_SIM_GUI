import os

def combine_binary_files_optimized(file1, file2, output_file, block_size=1024 * 1024):
    """
    İki SC16 Q11 formatındaki binary dosyayı birleştirir ve yeni bir binary dosya oluşturur.
    Bellek kullanımını minimize eder ve performansı artırır.

    Args:
        file1 (str): İlk binary dosyanın yolu (TX1 için).
        file2 (str): İkinci binary dosyanın yolu (TX2 için).
        output_file (str): Birleştirilmiş binary dosya çıkışı.
        block_size (int): Okuma/yazma işlemleri için kullanılacak blok boyutu (byte).
    """
    try:
        # Giriş dosyalarını ve çıkış dosyasını aç
        with open(file1, "rb") as f1, open(file2, "rb") as f2, open(output_file, "wb") as fout:
            while True:
                # Her dosyadan bir blok oku
                block1 = f1.read(block_size)
                block2 = f2.read(block_size)

                # Eğer herhangi bir dosyada veri biterse döngüyü durdur
                if not block1 or not block2:
                    break

                # İki blok veri birleştir ve yaz
                combined_block = bytearray()
                for i in range(0, min(len(block1), len(block2)), 4):  # Her 4 byte bir örnek
                    combined_block.extend(block1[i:i + 4])  # TX1 verisi
                    combined_block.extend(block2[i:i + 4])  # TX2 verisi

                fout.write(combined_block)

            # Artık kalan veri varsa işlenir
            remaining1 = f1.read()
            remaining2 = f2.read()
            if remaining1 or remaining2:
                print("Uyarı: Dosya boyutları eşit değil. Fazla veri işlenmedi.")

        print(f"Birleştirilmiş binary dosya oluşturuldu: {output_file}")

    except FileNotFoundError as e:
        print(f"Hata: Dosya bulunamadı - {e}")
    except Exception as e:
        print(f"Beklenmedik hata: {e}")

# Komut satırından dosya yollarını al
if __name__ == "__main__":
    import sys

    if len(sys.argv) != 4:
        print("Kullanım: python combine_binary_files_optimized.py <TX1 binary dosya yolu> <TX2 binary dosya yolu> <output binary dosya yolu>")
        sys.exit(1)

    binary_file1 = sys.argv[1]  # İlk dosya yolu (TX1 için)
    binary_file2 = sys.argv[2]  # İkinci dosya yolu (TX2 için)
    output_binary_file = sys.argv[3]  # Çıkış dosyası

    # Dosyaların varlığını kontrol et ve birleştir
    if not os.path.exists(binary_file1):
        print(f"Hata: {binary_file1} bulunamadı.")
        sys.exit(1)
    if not os.path.exists(binary_file2):
        print(f"Hata: {binary_file2} bulunamadı.")
        sys.exit(1)

    combine_binary_files_optimized(binary_file1, binary_file2, output_binary_file)
