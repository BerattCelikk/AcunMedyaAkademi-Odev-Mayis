# ASP.NET Core Authentication & Authorization

## Authentication Nedir?
Kullanıcının kimliğini doğrulama sürecidir. Farklı yöntemlerle yapılabilir.

## Cookie Authentication
- Kullanıcı bilgilerini **cookie** içinde saklar.
- Sunucu doğrulaması gerektirir.
- Statelidir.

## JWT Authentication
- Kullanıcı giriş yaptığında **token** oluşturur.
- **Stateless** olup her istekte doğrulanır.
- Mobil ve API kullanımları için uygundur.

## OAuth2 Authentication
- Google, Facebook gibi **harici sağlayıcılarla** kimlik doğrulama yapar.
- **Access Token** ile çalışır.

## Role-based Authorization
- Kullanıcının **rolüne** göre erişim izni verir.
- Örnek:
  ```csharp
  [Authorize(Roles = "Admin")]
  public IActionResult AdminPanel()
