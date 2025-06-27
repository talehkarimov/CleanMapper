using CleanMapper.Core;
using CleanMapper.Extensions;

public class MapperTests
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserProfile : MapProfile
    {
        public override void Configure(MappingConfiguration config)
        {
            config.CreateMap<UserDto, User>();
            config.CreateMap<User, UserDto>();
        }
    }

    public class IntToLongProfile : MapProfile
    {
        public override void Configure(MappingConfiguration config)
        {
            config.CreateMap<int, long>(i => (long)i);
        }
    }

    [Fact]
    public void Map_UserDto_To_User_Success()
    {
        var mapper = new Mapper(new UserProfile());
        var dto = new UserDto { Id = 1, Name = "Taleh" };

        var user = mapper.Map<UserDto, User>(dto);

        Assert.Equal(dto.Id, user.Id);
        Assert.Equal(dto.Name, user.Name);
    }

    [Fact]
    public void Map_User_To_UserDto_Success()
    {
        var mapper = new Mapper(new UserProfile());
        var user = new User { Id = 2, Name = "CleanMapper" };

        var dto = mapper.Map<User, UserDto>(user);

        Assert.Equal(user.Id, dto.Id);
        Assert.Equal(user.Name, dto.Name);
    }

    [Fact]
    public void MapList_UserDto_To_User_Success()
    {
        var mapper = new Mapper(new UserProfile());
        var dtos = new List<UserDto>
        {
            new UserDto { Id = 1, Name = "List1" },
            new UserDto { Id = 2, Name = "List2" }
        };

        var users = mapper.MapList<UserDto, User>(dtos).ToList();

        Assert.Equal(2, users.Count);
        Assert.Equal("List1", users[0].Name);
        Assert.Equal("List2", users[1].Name);
    }

    [Fact]
    public void MapArray_UserDto_To_User_Success()
    {
        var mapper = new Mapper(new UserProfile());
        var dtos = new[]
        {
            new UserDto { Id = 1, Name = "Array1" },
            new UserDto { Id = 2, Name = "Array2" }
        };

        var users = mapper.MapArray<UserDto, User>(dtos);

        Assert.Equal(2, users.Length);
        Assert.Equal("Array1", users[0].Name);
        Assert.Equal("Array2", users[1].Name);
    }

    [Fact]
    public void MapDictionary_UserDto_To_User_Success()
    {
        var mapper = new Mapper(new UserProfile());
        var dict = new Dictionary<int, UserDto>
        {
            { 1, new UserDto { Id = 1, Name = "Dict1" } },
            { 2, new UserDto { Id = 2, Name = "Dict2" } }
        };

        var usersDict = mapper.MapDictionary<int, UserDto, User>(dict);

        Assert.Equal(2, usersDict.Count);
        Assert.Equal("Dict1", usersDict[1].Name);
        Assert.Equal("Dict2", usersDict[2].Name);
    }

    [Fact]
    public void MapHashSet_UserDto_To_User_Success()
    {
        var mapper = new Mapper(new UserProfile());
        var dtos = new HashSet<UserDto>
        {
            new UserDto { Id = 1, Name = "Hash1" },
            new UserDto { Id = 2, Name = "Hash2" }
        };

        var users = mapper.MapHashSet<UserDto, User>(dtos);

        Assert.Equal(2, users.Count);
        Assert.Contains(users, u => u.Name == "Hash1");
        Assert.Contains(users, u => u.Name == "Hash2");
    }

    [Fact]
    public void MapNullable_Int_To_Long_Success()
    {
        var mapper = new Mapper(new IntToLongProfile());
        int? value = 123;

        var result = mapper.MapNullable<int, long>(value);

        Assert.True(result.HasValue);
        Assert.Equal(123L, result.Value);
    }

    [Fact]
    public void MapNullable_Null_Returns_Null()
    {
        var mapper = new Mapper(new IntToLongProfile());
        int? value = null;

        var result = mapper.MapNullable<int, long>(value);

        Assert.Null(result);
    }

    [Fact]
    public void Map_Without_Config_Throws_Exception()
    {
        var mapper = new Mapper();

        Assert.Throws<InvalidOperationException>(() =>
            mapper.Map<UserDto, User>(new UserDto { Id = 1, Name = "NoConfig" }));
    }
}
