# CreWin Project Documentation

## Project Overview
CreWin is an ASP.NET Core MVC application that integrates with the DummyJSON API to display product categories and their details. The application follows a clean architecture pattern with separate models for different entities and controllers for specific functionalities.

## Project Structure

### Models

#### 1. CategoryViewModel
```csharp
public class CategoryViewModel
{
    [Required]
    [DisplayName("Product Slug")]
    public string Slug { get; set; }

    [Required]
    [DisplayName("Product Name")]
    public string Name { get; set; }

    [Required]
    public string Url { get; set; }
}
```

#### 2. ProductViewModel
```csharp
public class ProductViewModel
{
    [Required]
    [DisplayName("id")]
    public int id { get; set; }
    
    [Required]
    [DisplayName("title")]
    public string title { get; set; }
    
    [Required]
    [DisplayName("description")]
    public string description { get; set; }
    
    [Required]
    [DisplayName("category")]
    public string category { get; set; }
    
    [Required]
    [DisplayName("price")]
    public double price { get; set; }
    
    [Required]
    [DisplayName("discountPercentage")]
    public double discountPercentage { get; set; }
    
    [Required]
    [DisplayName("rating")]
    public double rating { get; set; }
    
    [Required]
    [DisplayName("stock")]
    public int stock { get; set; }
}
```

#### 3. ErrorViewModel
```csharp
public class ErrorViewModel
{
    public string? RequestId { get; set; }
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
```

### Controllers

#### 1. HomeController
Basic controller providing navigation to main pages:
- Index
- Privacy
- Product
- Details

```csharp
public class HomeController : Controller
{
    public IActionResult Index()
    public IActionResult Privacy()
    public IActionResult Product()
    public IActionResult Details()
}
```

#### 2. ProductController
Main controller handling product-related operations:

```csharp
public class ProductController : Controller
{
    // Base URL configuration
    Uri baseAdresses = new Uri("https://dummyjson.com/");
    private readonly HttpClient _client;

    // Endpoints
    [HttpGet] public async Task Index()
    [HttpGet][Route("Product/Details/{slug}")] public async Task Details(string slug)
}
```

#### Helper Classes
```csharp
public class ProductsResponse
{
    [JsonProperty("products")]
    public List Products { get; set; }
}
```

## API Integration

### Endpoints Used
1. Categories Endpoint
   - URL: `https://dummyjson.com/products/categories`
   - Method: GET
   - Response: List of categories

2. Product Details by Category
   - URL: `https://dummyjson.com/products/category/{slug}`
   - Method: GET
   - Response: List of products in category

### Error Handling
- Try-catch blocks for exception handling
- Debug logging at key points
- Fallback to empty lists on errors
- Null checking for parameters

## Routing Structure

### URL Patterns
1. Home Routes:
   - `/` - Home Index
   - `/Home/Privacy` - Privacy Page
   - `/Home/Product` - Product Page
   - `/Home/Details` - Details Page

2. Product Routes:
   - `/Product/Index` - Categories List
   - `/Product/Details/{slug}` - Category Products
   Example: `/Product/Details/womens-watches`

## Data Flow

### 1. Category Listing Process
1. User makes request to Index page
2. ProductController.Index method is called
3. API request is made to categories endpoint
4. JSON response is parsed
5. CategoryViewModel objects are created
6. View is returned with data

### 2. Product Details Process
1. User clicks category with slug
2. ProductController.Details method is called
3. Slug is validated
4. API request is made with slug
5. JSON response is parsed into ProductViewModel list
6. View is returned with product data

## Development Guidelines

### Adding New Features
1. Create appropriate ViewModel in Models folder
2. Add necessary validation attributes
3. Create or update Controller actions
4. Implement error handling and logging
5. Create corresponding Views

### Best Practices
1. Use async/await for API calls
2. Implement proper error handling
3. Use Debug.WriteLine for logging
4. Follow REST principles
5. Use proper route attributes
6. Validate input parameters

## Setup and Configuration

### Prerequisites
- .NET Core SDK
- Visual Studio 2019 or later
- Internet connection for API access

### Installation Steps
1. Clone repository
2. Restore NuGet packages
3. Build solution
4. Run application

### Configuration Points
- Base URL in ProductController
- Route templates
- API endpoints

## Testing

### Key Test Areas
1. Category listing
2. Product details retrieval
3. Error handling
4. Null parameter handling
5. API response parsing
6. View model mapping

## Future Enhancements
1. Implement caching
2. Add authentication
3. Enhance error handling
4. Add product search
5. Implement pagination
6. Add product filtering
7. Enhance logging
8. Add unit tests
9. Implement API response caching
10. Add user interface improvements

## Troubleshooting

### Common Issues
1. API Connection Issues
   - Check base URL configuration
   - Verify network connectivity
   - Check API response status codes

2. Data Parsing Issues
   - Verify JSON structure
   - Check model property mappings
   - Debug response data

### Debug Logs
Look for debug output with:
- Request URLs
- Response status codes
- Response data
- Exception messages

## Contributing
1. Fork repository
2. Create feature branch
3. Follow coding standards
4. Add appropriate comments
5. Submit pull request

## License
MIT License
