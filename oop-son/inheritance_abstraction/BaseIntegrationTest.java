@Testcontainers
public abstract class BaseIntegrationTest {

    private static final MongoDBContainer mongo;
    private static final GenericContainer<?> redis;

    static {
        mongo = new MongoDBContainer("mongo:6.0")
                .withReuse(true)
                .waitingFor(Wait.forLogMessage(".*Waiting for connections.*", 1))
                .withStartupTimeout(Duration.ofSeconds(60));
        mongo.start(); // start 1 lần cho toàn bộ JVM

        redis = new GenericContainer<>("redis:7.2.4")
                .withReuse(true)
                .withExposedPorts(6379)
                .waitingFor(Wait.forListeningPort())
                .withStartupTimeout(Duration.ofSeconds(30));
        redis.start(); // start 1 lần cho toàn bộ JVM
    }

    @DynamicPropertySource
    static void setProperties(DynamicPropertyRegistry registry) {
        registry.add("spring.data.mongodb.uri", mongo::getReplicaSetUrl);
        registry.add("spring.data.redis.host", redis::getHost);
        registry.add("spring.data.redis.port", redis::getFirstMappedPort);
    }
}