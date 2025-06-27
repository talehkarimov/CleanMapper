# 📂 Using Profiles in CleanMapper

Profiles in CleanMapper group your mappings logically.

---

## ✨ Why use profiles?

✔️ Organize mappings per domain or module  
✔️ Register multiple profiles in a single mapper

---

## 💻 Example

```csharp
public class OrderProfile : MapProfile
{
    public override void Configure(MappingConfiguration config)
    {
        config.CreateMap<OrderDto, Order>();
        config.CreateMap<OrderItemDto, OrderItem>();
    }
}
```

---

## ➡️ Adding multiple profiles

```csharp
var mapper = new Mapper(new UserProfile(), new OrderProfile());
```

---

✅ **Best Practice:** Create separate profiles for each module to keep configurations clean.