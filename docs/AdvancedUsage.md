# 💡 Advanced Usage of CleanMapper

Explore advanced features, limitations, and performance insights.

---

## ⚙️ Custom Mapping Functions

You can define custom mappings manually:

```csharp
config.CreateMap<int, long>(i => (long)i);
```

---

## 🚀 Performance

CleanMapper uses **expression trees** to generate mappings at configuration time and compiles them to delegates for **runtime performance without reflection**.

---

## ⚠️ Limitations (v1.0.0)

- No automatic nested mapping (planned for v1.1.0)
- Does not support custom value resolvers yet