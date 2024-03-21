using System.ComponentModel.DataAnnotations;
namespace _20240322Test01.StaticTypedDomain;

public record Email([property:EmailAddress]string Value);
public interface EmailContactInfo2;
public record VerifiedEmailAddress(Email Email) : EmailContactInfo2;
public record UnverifiedEmailAddress(Email Email) : EmailContactInfo2;
public record Customer(string Name, EmailContactInfo2 ContactInfo);

public static class EmailService2
{
    public static async Task<EmailContactInfo2> ValidateEmailAsync(Email email)
    {
        // 何か長い処理で検証する。正しいメールアドレスというだけでなく
        // 送信しても大丈夫かなども検証する。
        await Task.CompletedTask;
        var isValid = true;
        
        return isValid ? 
            new VerifiedEmailAddress(email) 
            : new UnverifiedEmailAddress(email);
    }
    public static bool ResetEmail(VerifiedEmailAddress email, string name)
    {
        // リセットメールを送る failed@example.com の時だけ失敗（仮）
        var result = !email.Email.Value.Equals("failed@example.com"); 
        return result;
    }
}
public static class CustomerService2
{
    public static string PasswordResetRequested(Customer customer)
    {
        return customer.ContactInfo switch
        {
            VerifiedEmailAddress verified => EmailService2.ResetEmail(verified, customer.Name) 
                    ? "Success" : "Failed",
            _ => "Customer Email is not verified."
        }; 
    }
}
