module _20240322Fs.StaticTypedDomain


type EmailAddress = EmailAddress of string

type VerifiedEmail = VerifiedEmail of EmailAddress
type UnverifiedEmail = UnverifiedEmail of EmailAddress

type EmailContactInfo = VerifiedEmail | UnverifiedEmail

