# **Semantik Versiyonlama (Semantic Versioning - SemVer)**

## **Versiyonlama Formatı: `MAJOR.MINOR.PATCH`**

### **MAJOR (Ana Versiyon):**
- Projede geri uyumsuz (breaking) değişiklikler yapıldığında artırılır.
- Örneğin, bir API'nin tamamen değiştirilmesi veya önceki sürümlerle çalışmayan büyük değişiklikler yapıldığında.
  **Örnek:** `1.0.0 → 2.0.0`

---

### **MINOR (Alt Versiyon):**
- Geri uyumlu yeni özellikler veya iyileştirmeler eklediğinizde artırılır.
- Eski kod veya kullanıcılar etkilenmez.
  **Örnek:** `1.0.0 → 1.1.0`

---

### **PATCH (Düzeltme):**
- Küçük hata düzeltmeleri veya performans iyileştirmeleri yapıldığında artırılır.
- Projenin işleyişinde veya mevcut özelliklerinde herhangi bir değişiklik yapılmaz.
  **Örnek:** `1.0.0 → 1.0.1`
