using _20240322Test01.Domain;
namespace _20240322Test01;

public class TestDomain
{
    [Fact]
    public void TestShouldFailWhenIsVerifiedFalse()
    {
        var email = new EmailContactInfo(new Email("test@example.com"), false);
        var result = EmailService.ResetEmail(email, "John Doe");
        Assert.False(result);
    }
    
    [Fact]
    public void TestShouldSuccessWhenIsVerifiedTrue()
    {
        var email = new EmailContactInfo(new Email("test@example.com"), true);
        var result = EmailService.ResetEmail(email, "John Doe");
        Assert.True(result);
    }
    [Fact]
    public void PasswordResetRequestedShouldSuccessWithVerifiedEmail()
    {
        var customer = new Customer(
            "John Doe",
            new EmailContactInfo(new Email("test@example.com"), true));
        var result = CustomerService.PasswordResetRequested(customer);
        Assert.Equal("Success", result);
    }
    [Fact]
    public void PasswordResetRequestedShouldFailedWithVerifiedEmail()
    {
        var customer = new Customer(
            "John Doe",
            new EmailContactInfo(new Email("failed@example.com"), true));
        var result = CustomerService.PasswordResetRequested(customer);
        Assert.Equal("Failed", result);
    }
    [Fact]
    public void PasswordResetRequestedShouldFailedWithUnverifiedEmail()
    {
        var customer = new Customer(
            "John Doe",
            new EmailContactInfo(new Email("test@example.com"), false));
        var result = CustomerService.PasswordResetRequested(customer);
        Assert.Equal("Customer Email is not verified.", result);
    }
}
