open System

type Record = 
    {
        Experience  : string
        Source      : string
        Education   : string
        Hired       : bool 
    }

    member this.GetAttributeValue(attribute) =
        match attribute with
        | "Experience"  -> this.Experience
        | "Source"      -> this.Source
        | "Education"   -> this.Education
        | _ -> failwithf "Invalid attribute '%s'" attribute

    override this.ToString() =
        sprintf
            "[Experience = %s | Source = %s | Education = %s | Hired = %b]" 
            this.Experience
            this.Source 
            this.Education
            this.Hired

let data =
    let none, oneToFive, fiveToTen, tenPlus = "None", "1-5 years", "5-10 years", "10+ years"
    let email, letter, socialMedia, internalHire, unknown = "Email", "Letter", "Social media", "Internal hire", "Unknown"
    let uni, hbo, mbo, lbo, college = "University", "HBO", "MBO", "LBO", "College"
    let yes, no = true, false

    let newRec exp source edu hired = 
        { Experience = exp; Source = source; Education = edu; Hired = hired }

    [
        newRec none          email        uni      no
        newRec none          email        uni      no
        newRec oneToFive     email        hbo      yes
        newRec fiveToTen     letter       hbo      yes
        newRec fiveToTen     letter       college  yes
        newRec fiveToTen     socialMedia  college  no
        newRec oneToFive     socialMedia  uni      yes
        newRec none          socialMedia  hbo      no
        newRec none          letter       mbo      yes
        newRec fiveToTen     letter       mbo      yes
        newRec none          socialMedia  uni      yes
        newRec oneToFive     internalHire hbo      yes
        newRec oneToFive     email        hbo      yes
        newRec tenPlus       unknown      mbo      no
    ]

printfn "Dataset = \n"
data |> List.iter (printfn "%O")

let endProg = Console.ReadLine();