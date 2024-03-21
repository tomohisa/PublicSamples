using System.ComponentModel.DataAnnotations;
namespace _20240322Test01.Domain;

public record Email([property:EmailAddress]string Value);
public record EmailContactInfo(Email Email, bool IsVerified);
public record Customer(string Name, EmailContactInfo ContactInfo);

public static class EmailService
{
    public static async Task<EmailContactInfo> ValidateEmailAsync(Email email)
    {
        // 何か長い処理で検証する。正しいメールアドレスというだけでなく
        // 送信しても大丈夫かなども検証する。
        await Task.CompletedTask;
        var isValid = true;
        
        return new EmailContactInfo(email, isValid);
    }
    public static bool ResetEmail(EmailContactInfo email, string name)
    {
        if (email.IsVerified)
        {
            // リセットメールを送る failed@example.com の時だけ失敗（仮）
            var result = ! email.Email.Value.Equals("failed@example.com"); 
            return result;
        }
        return false;
    }
}
public static class CustomerService
{
    public static string PasswordResetRequested(Customer customer)
    {
        return customer.ContactInfo.IsVerified switch
        {
            true => EmailService.ResetEmail(customer.ContactInfo, customer.Name) 
                    ? "Success" : "Failed",
            _ => "Customer Email is not verified."
        };
    }
}

