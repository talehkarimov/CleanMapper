# CleanMapper

**CleanMapper** is a lightweight, reflection-minimal object mapping library for .NET. It provides AutoMapper-like functionality with a cleaner, faster, and minimalistic design.

## ?? Features

- Strongly typed mapping registration
- Auto-map properties with same name and type
- Profile-based configuration
- Map collections with extension methods
- Lightweight with no runtime reflection during mapping

## ? Installation

```bash
dotnet add package CleanMapper
```

## ? Usage

```csharp
var mapper = new Mapper(new UserProfile());

var dto = new UserDto { Id = 1, Name = "Taleh" };
var user = mapper.Map<UserDto, User>(dto);
```

### **Create a Profile**

```csharp
public class UserProfile : MapProfile
{
    public override void Configure(MappingConfiguration config)
    {
        config.CreateMap<UserDto, User>();
        config.CreateMap<User, UserDto>();
    }
}
```

### **Map List**

```csharp
var users = mapper.MapList<UserDto, User>(userDtos);
```

## ? Roadmap

- Custom value resolvers
- Conditional mapping
- Reverse mapping via fluent API
- Nested and flattening mappings

## ?? License

MIT

---

**Built with ?? by Taleh Karimov**