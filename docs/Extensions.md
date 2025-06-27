# 🛠 Extensions in CleanMapper

CleanMapper provides extension methods for mapping collections and advanced scenarios.

---

## ✨ Supported Extensions

- `MapList<TSource, TDestination>()`
- `MapArray<TSource, TDestination>()`
- `MapDictionary<TKey, TSource, TDestination>()`
- `MapHashSet<TSource, TDestination>()`
- `MapNullable<TSource, TDestination>()`

---

## 💻 Example: Map List

```csharp
using CleanMapper.Extensions;

var users = mapper.MapList<UserDto, User>(userDtos).ToList();
```

---

## ⚠️ Note

To use these extensions, add:

```csharp
using CleanMapper.Extensions;
```

Or add it as a **global using** for convenience.

---

See [AdvancedUsage.md](AdvancedUsage.md) for custom mappings and performance notes.