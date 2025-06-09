using Xunit;
using Triskai.Core;

public class ObjectManagerTests
{
    class TestGameObject : IGameObject
    {
        public string Id { get; set; }

        public int Priority { get; set; }

        public float elapsedTicks = 0;

        public TestGameObject(string id = "", int priority = 0)
        {
            Id = id;
            Priority = priority;
            elapsedTicks = 0;
        }

        public void Tick(float deltaTime)
        {
            elapsedTicks += deltaTime;
        }
    }

    class TestPhysicsObject : IPhysicsObject
    {
        public string Id { get; set; }

        public int Priority { get; set; }

        public float elapsedTicks = 0;

        public TestPhysicsObject(string id = "", int priority = 0)
        {
            Id = id;
            Priority = priority;
            elapsedTicks = 0;
        }

        public void Tick(float deltaTime)
        {
            elapsedTicks += deltaTime;
        }
    }

    class GenericObject : ITickableObject
    {
        public string Id { get; set; }
        public float elapsedTicks = 0;

        public GenericObject(string id = "")
        {
            Id = id;
        }

        public void Tick(float deltaTime)
        {
            elapsedTicks += deltaTime;
        }
    }


    [Fact]
    public void ObjectManagement_TestObjects()
    {
        // create objects and test their functionality
        var gameObject = new TestGameObject("gameObject", 0);
        var physicsObject = new TestPhysicsObject("physicsObject", 2);
        var genericObject = new GenericObject("genericObject");

        // check if they have properly been initialized
        Assert.Equal("gameObject", gameObject.Id);
        Assert.Equal(0, gameObject.Priority);

        Assert.Equal("physicsObject", physicsObject.Id);
        Assert.Equal(2, physicsObject.Priority);

        Assert.Equal("genericObject", genericObject.Id);

        // check if they tick properly
        gameObject.Tick(1.0f);
        physicsObject.Tick(1.0f);
        genericObject.Tick(1.0f);


        Assert.Equal(1.0f, gameObject.elapsedTicks);
        Assert.Equal(1.0f, physicsObject.elapsedTicks);
        Assert.Equal(1.0f, genericObject.elapsedTicks);
    }

    [Fact]
    public void ObjectManagement_TestObjectManagerParallelRegistration()
    {
        var manager = new ObjectManager();

        // create a shit ton of objects, and have it run.
        // I think a 100 objects is good
        var gameObjects = Enumerable.Range(0, 100000)
            .Select(_ => new GenericObject())
            .ToArray();

        // we're going to register all 100.
        manager.RegisterMany(gameObjects, true);

        // check if all of them have received a proper Id.
        foreach (var gameObject in gameObjects)
        {
            Assert.True(manager.GetObject(gameObject.Id, out _));
        }

        // ensure no duplicate ids
        var ids = gameObjects.Select(o => o.Id).ToList();
        Assert.Equal(ids.Count, ids.Distinct().Count());
        Assert.All(ids, id => Assert.False(string.IsNullOrWhiteSpace(id)));
    }

    [Fact]
    public void ObjectManagement_TestObjectManagerRegistration()
    {
        var manager = new ObjectManager();

        var gameObject = new GenericObject();

        manager.Register(gameObject);

        Assert.True(manager.GetObject(gameObject.Id, out var obj));
        Assert.Equal(gameObject, obj);
    }

    [Fact]
    public void ObjectManagement_TestObjectManagerTickSingle()
    {
        var manager = new ObjectManager();
        var gameObject = new GenericObject();

        manager.Register(gameObject);

        manager.Tick(1.0f);

        Assert.True(manager.GetObject(gameObject.Id, out var obj));
        Assert.Equal(gameObject.elapsedTicks, ((GenericObject)obj).elapsedTicks);

        Assert.Equal(1.0f, gameObject.elapsedTicks);
    }

    [Fact]
    public void ObjectManagement_TestObjectManagerParallelTicks()
    {
        var manager = new ObjectManager();

        // create a shit ton of objects, and have it run.
        // I think a 100 objects is good
        var gameObjects = Enumerable.Range(0, 100000)
            .Select(_ => new GenericObject())
            .ToArray();

        // we're going to register all 100.
        manager.RegisterMany(gameObjects, true);

        manager.Tick(1.0f);

        Assert.All(gameObjects, gameObject => Assert.Equal(1.0f, gameObject.elapsedTicks));
    }
}