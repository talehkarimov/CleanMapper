# 🚀 Getting Started with CleanMapper

CleanMapper is a lightweight, strongly-typed object mapping library for .NET. This guide helps you integrate it quickly.

---

## ✨ Installation

Install via NuGet:

```bash
dotnet add package CleanMapper
```

Or via Package Manager:

```powershell
Install-Package CleanMapper
```

---

## 💻 Basic Usage

### ➡️ 1. Create a Profile

```csharp
using CleanMapper.Core;

public class UserProfile : MapProfile
{
    public override void Configure(MappingConfiguration config)
    {
        config.CreateMap<UserDto, User>();
        config.CreateMap<User, UserDto>();
    }
}
```

---

### ➡️ 2. Map objects

```csharp
var mapper = new Mapper(new UserProfile());

var dto = new UserDto { Id = 1, Name = "Taleh" };
var user = mapper.Map<UserDto, User>(dto);
```

---

For mapping collections or advanced scenarios, see [Extensions.md](Extensions.md).