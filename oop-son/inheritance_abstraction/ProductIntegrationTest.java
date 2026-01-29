@SpringBootTest
@AutoConfigureMockMvc(addFilters = false)
@TestPropertySource(locations = "classpath:application-test.yml")
@DisplayName("Product Integration Tests")
public class ProductIntegrationTest extends BaseIntegrationTest {

    @Autowired
    private MockMvc mockMvc;

    @Autowired
    private RedisTemplate<String, Object> redisTemplate;

    @Autowired
    private ProductRepository productRepository;

    private final ObjectMapper objectMapper = new ObjectMapper();

    // Constants - tránh lặp lại magic strings
    private static final String PRODUCTS_URL = "/products";
    private static final String PRODUCT_BY_ID_URL = "/products/{productId}";
    private static final String VALID_PRODUCT_ID = "68ad8b8f1f76bd5e1eb753cd";
    private static final String NOT_FOUND_PRODUCT_ID = "68aaee0ad86372261d4b5e4e";
    private static final String INVALID_PRODUCT_ID = "66aaa1111111111111111";

    @BeforeEach
    void setUp() throws InterruptedException {
        Assertions.assertNotNull(redisTemplate.getConnectionFactory());
        Thread.sleep(500); // chờ Redis ổn định (nếu container vừa lên)

        try {
            redisTemplate.getConnectionFactory().getConnection().flushAll();
        } catch (Exception e) {
            // Retry 1 lần sau 300ms nếu Redis chưa kịp ready
            Thread.sleep(300);
            redisTemplate.getConnectionFactory().getConnection().flushAll();
        }
        productRepository.deleteAll();
    }

    @AfterAll
    static void cleanUp(@Autowired RedisTemplate<String, Object> redisTemplate) {
        redisTemplate.getConnectionFactory().getConnection().close();
    }

    // Helper methods - tránh duplicate code
    private Product createSampleProduct(String id, String name) {
        return Product.builder()
                .id(new ObjectId(id))
                .name(name)
                .description("Sample Description")
                .price(10.0)
                .category("FOOD")
                .build();
    }

    private CreateProductRequest createValidProductRequest() {
        CreateProductRequest request = new CreateProductRequest();
        request.setName("New Food Product");
        request.setDescription("New Food Description");
        request.setPrice(10.0);
        request.setCategory("FOOD");
        return request;
    }

    private UpdateProductRequest createValidUpdateRequest() {
        UpdateProductRequest request = new UpdateProductRequest();
        request.setName("Update Food Product");
        request.setDescription("Update Food Description");
        request.setPrice(100.0);
        request.setCategory("FOOD");
        return request;
    }

    @Nested
    @DisplayName("View All Products")
    class ViewAllProductsTests {

        @Test
        @DisplayName("Should return paged results when products exist")
        void whenProductsExist_returnPagedResult() throws Exception {
            // Given
            List<Product> products = List.of(
                    createSampleProduct(VALID_PRODUCT_ID, "Sample Food Product 1"),
                    createSampleProduct("68ad8b8f1f76bd5e1eb753ce", "Sample Food Product 2")
            );
            productRepository.saveAll(products);

            // When & Then
            mockMvc.perform(get(PRODUCTS_URL)
                            .param("page", "0")
                            .param("size", "10")
                            .contentType(MediaType.APPLICATION_JSON))
                    .andExpect(status().isOk())
                    .andExpect(jsonPath("$.code").value(200))
                    .andExpect(jsonPath("$.result.content").isArray())
                    .andExpect(jsonPath("$.result.totalElements").value(2))
                    .andExpect(jsonPath("$.result.content[0].name").value("Sample Food Product 1"));
        }

        @Test
        @DisplayName("Should return empty page when no products exist")
        void whenNoProductsExist_returnEmptyPage() throws Exception {
            mockMvc.perform(get(PRODUCTS_URL)
                            .param("page", "0")
                            .param("size", "5")
                            .contentType(MediaType.APPLICATION_JSON))
                    .andExpect(status().isOk())
                    .andExpect(jsonPath("$.code").value(200))
                    .andExpect(jsonPath("$.result.content").isArray())
                    .andExpect(jsonPath("$.result.totalElements").value(0));
        }
    }