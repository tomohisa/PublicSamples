using _20240322Test01.StaticTypedDomain;
namespace _20240322Test01;

public class TestStaticTypedDomain
{
    [Fact]
    public void TestShouldSuccessWhenIsVerifiedTrue()
    {
        var email = new VerifiedEmailAddress(new Email("test@example.com"));
        var result = EmailService2.ResetEmail(email, "John Doe");
        Assert.True(result);
    }
    // 不要になるテスト
    // [Fact]
    // public void TestShouldSuccessWhenIsVerifiedFalse()
    // {
    //     var email = new UnverifiedEmailAddress(new Email("test@example.com"));
    //     // コンパイルでUnverifiedEmailAddressを渡すことができないので、このテスト自体
    //     // は書けないし、書く必要がない
    //     var result = EmailService2.ResetEmail(email, "John Doe");
    //     Assert.True(result);
    // }

    [Fact]
    public void PasswordResetRequestedShouldSuccessWithVerifiedEmail()
    {
        var customer = new Customer(
            "John Doe",
            new VerifiedEmailAddress(new Email("test@example.com")));
        var result = CustomerService2.PasswordResetRequested(customer);
        Assert.Equal("Success", result);
    }
    [Fact]
    public void PasswordResetRequestedShouldFailedWithVerifiedEmail()
    {
        var customer = new Customer(
            "John Doe",
            new VerifiedEmailAddress(new Email("failed@example.com")));
        var result = CustomerService2.PasswordResetRequested(customer);
        Assert.Equal("Failed", result);
    }
    [Fact]
    public void PasswordResetRequestedShouldFailedWithUnverifiedEmail()
    {
        var customer = new Customer(
            "John Doe",
            new UnverifiedEmailAddress(new Email("test@example.com")));
        var result = CustomerService2.PasswordResetRequested(customer);
        Assert.Equal("Customer Email is not verified.", result);
    }
}
