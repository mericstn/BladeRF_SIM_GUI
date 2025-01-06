import csv
import sys
import re
from datetime import datetime

# Kullanıcıdan alınan dosya yolunu al
file_path = sys.argv[1]

# GPS zamanının başlangıç tarihi
GPS_START = datetime(1980,1,6)

# Dosya adından tarih bilgilerini almak için bir düzenli ifade modeli (regex)
DATE_PATTERN = r'([0-9]{2})_([A-Z]{3})_([0-9]{4})_GST_([0-9]{2})_([0-9]{2})_([0-9]{2}).csv'

# Ay isimlerini numaralara çevirme tablosu
month2num = {'JAN':1, 'FEB':2, 'MAR':3, 'APR':4, 'MAY':5, 'JUN':6, 'JUL':7, 'AUG':8, 'SEP':9, 'OCT':10, 'NOV':11, 'DEC':12}

# Dosya adından WN ve TOW hesaplamak
try:
    regex_result = re.search(DATE_PATTERN, file_path)
    day, month, year, hour, minute, second = regex_result.groups()
    print(f"Tarih bilgisi dosya isminden alındı: {day}-{month}-{year} {hour}:{minute}:{second}")
except:
    print(f"No patterns found in file name: {file_path}")
    exit(1)

# Ay isimlerini sayıya çevirme
month = month2num[month]

# Tarihi GPS başlangıç tarihi ile karşılaştırmak için `epoch` hesapla
epoch = datetime(int(year), int(month), int(day), int(hour), int(minute), int(second))
delta = epoch - GPS_START

# Haftanın numarası (WN) ve hafta içi saniye (TOW) hesapla
wn = delta.days // 7
tow = delta.days % 7 * 86400 + delta.seconds
print(f"WN (Week Number): {wn}, TOW (Time of Week): {tow}")

# Sabitler
bits_per_page = 240
hex_per_page = bits_per_page // 4
max_pages = 0

# Uydu ID'lerine göre her birinin nav mesajlarını tutan bir sözlük
nav_message_dict = {}

# CSV dosyasını oku
with open(file_path, 'r') as csv_file:
    csv_reader = csv.DictReader(csv_file)
    
    for line in csv_reader:
        nav_bits_hex = line['NavBitsHEX']
        number_of_pages = int(line['NumNavBits']) // 240
        
        # Her satırdaki verileri `nav_message_dict` içine yerleştir
        nav_message_dict[int(line['SVID'])] = [
            nav_bits_hex[i * hex_per_page:i * hex_per_page + hex_per_page] 
            for i in range(number_of_pages)
        ]
        
        # Max sayfa sayısını kaydet
        if number_of_pages > max_pages:
            max_pages = number_of_pages

print(f"Toplam maksimum sayfa sayısı: {max_pages}")
print(f"Uydu mesajları: {nav_message_dict}")

# Tüm sayfaları saklamak için liste
list_of_pages = []

# Tüm sayfaları işleyerek `list_of_pages` listesine ekle
for page in range(max_pages):
    for svid, nav_data in nav_message_dict.items():
        try:
            list_of_pages.append([tow, wn - 1024, svid, nav_data[page]])
        except IndexError:
            print(f"Error: Uydu {svid} için sayfa {page} eksik!")
    tow += 2

print("Toplam sayfa sayısı kaydedildi:", len(list_of_pages))

# Çıktıyı yeni bir CSV dosyasına yaz
output_file = file_path[:file_path.rfind('.')] + '_fixed.csv'
with open(output_file, 'w') as out_file:
    csv_writer = csv.writer(out_file)
    csv_writer.writerows(list_of_pages)

print(f"Veriler '{output_file}' dosyasına kaydedildi.")
