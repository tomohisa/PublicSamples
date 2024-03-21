module _20240322Fs.Domain

open System


type EmailAddress = EmailAddress of string

type EmailContactInfo = {
    EmailAddress: EmailAddress
    IsEmailVerified: bool
}

Console.WriteLine("Hello World")


