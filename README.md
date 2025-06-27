[![NuGet Version](https://img.shields.io/nuget/v/CleanMapper.svg)](https://www.nuget.org/packages/CleanMapper/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.txt)

# 🧹 CleanMapper


# 🧹 CleanMapper

**CleanMapper** is a lightweight, reflection-minimal object mapping library for .NET. It enables fast, strongly-typed mappings between DTOs, ViewModels, and domain models with a clean and minimal API design.

---

## ✨ Features

- ✅ Strongly-typed mapping registration
- ✅ Auto-maps properties with matching names and types
- ✅ Profile-based configuration for organized mappings
- ✅ Extension methods for mapping collections and advanced scenarios
- ✅ Lightweight with no runtime reflection during mapping

---

## 🚀 Installation

Install via NuGet:

```bash
dotnet add package CleanMapper
```

Or via the Package Manager:

```powershell
Install-Package CleanMapper
```

---

## 💻 Usage

### ➡️ 1. Create a Profile

Define a mapping profile to configure your mappings:

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

### ➡️ 3. Map lists

```csharp
using CleanMapper.Extensions; // ⚠️ Required for extension methods

var userDtos = new List<UserDto>
{
    new UserDto { Id = 1, Name = "Alice" },
    new UserDto { Id = 2, Name = "Bob" }
};

var users = mapper.MapList<UserDto, User>(userDtos).ToList();
```

> 💡 **Note:** To use `MapList`, `MapArray`, and other collection mapping extensions, ensure you add:
> 
> ```csharp
> using CleanMapper.Extensions;
> ```
> 
> Or add it as a **global using** in your project for convenience.

---

## 🤝 Contributing

Contributions, issues, and feature requests are welcome!  
Please open an issue to discuss improvements or submit a pull request directly.

---

## 📄 License

This project is licensed under the MIT License. See [LICENSE.txt](LICENSE.txt) for details.

---

### 🙌 Author

**CleanMapper** is built with dedication by [Taleh Karimov](https://github.com/talehkarimov).

---

⭐ **Star this repository** if you find it helpful, and follow for upcoming advanced mapping features!
