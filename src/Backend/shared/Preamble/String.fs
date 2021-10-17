[<RequireQualifiedAccess>]
module String

// Empty

let empty = System.String.Empty


// Compare

let internal ordinal = System.StringComparison.Ordinal
let internal ordinalIgnore = System.StringComparison.OrdinalIgnoreCase
let internal culture = System.StringComparison.CurrentCulture
let internal cultureIgnore = System.StringComparison.CurrentCultureIgnoreCase
let internal invariant = System.StringComparison.InvariantCulture
let internal invariantIgnore = System.StringComparison.InvariantCultureIgnoreCase

let compareToWith (comparison: System.StringComparison) strB strA = System.String.Compare(strA, strB, comparison)

let compareTo = compareToWith ordinal
let compareIgnoreCaseTo = compareToWith ordinalIgnore
let compareCurrentCultureTo = compareToWith culture
let compareCurrentCultureIgnoreCaseTo = compareToWith cultureIgnore
let compareInvariantCultureTo = compareToWith invariant
let compareInvariantCultureIgnoreCaseTo = compareToWith invariantIgnore


// Equals

let equalsToWith (comparison: System.StringComparison) strB strA = System.String.Equals(strA, strB, comparison)

let equalsTo = equalsToWith ordinal
let equalsIgnoreCaseTo = equalsToWith ordinalIgnore
let equalsCurrentCultureTo = equalsToWith culture
let equalsCurrentCultureIgnoreCaseTo = equalsToWith cultureIgnore
let equalsInvariantCultureTo = equalsToWith invariant
let equalsInvariantCultureIgnoreCaseTo = equalsToWith invariantIgnore


// Intern, IsInterned, Normalize, IsNormalized

let internal formC = System.Text.NormalizationForm.FormC
let internal formD = System.Text.NormalizationForm.FormD
let internal formKC = System.Text.NormalizationForm.FormKC
let internal formKD = System.Text.NormalizationForm.FormKD

let intern str = System.String.Intern(str)
let isInterned str = System.String.IsInterned(str)

let normalize (str: string) = str.Normalize()
let normalizeWith form (str: string) = str.Normalize(form)
let normalizeFormC = normalizeWith formC
let normalizeFormD = normalizeWith formD
let normalizeFormKC = normalizeWith formKC
let normalizeFormKD = normalizeWith formKD

let isNormalized (str: string) = str.IsNormalized()
let isNormalizedWith form (str: string) = str.IsNormalized(form)
let isNormalizedFormC = isNormalizedWith formC
let isNormalizedFormD = isNormalizedWith formD
let isNormalizedFormKC = isNormalizedWith formKC
let isNormalizedFormKD = isNormalizedWith formKD


// IsNullOrEmpty, IsNullOrWhiteSpace

let isNullOrEmpty str = System.String.IsNullOrEmpty(str)
let isNullOrWhiteSpace str = System.String.IsNullOrWhiteSpace(str)
let isNotNullOrEmpty = isNullOrEmpty >> not
let isNotNullOrWhiteSpace = isNullOrWhiteSpace >> not


// IndexOf


let indexOfCharWith (comparison: System.StringComparison) (ch: char) (str: string) =
    str.IndexOf(ch, comparison)

let indexOfChar = indexOfCharWith ordinal
let indexCharIgnoreCaseOf = indexOfCharWith ordinalIgnore
let indexCharCurrentCultureOf = indexOfCharWith culture
let indexCharCurrentCultureIgnoreCaseOf = indexOfCharWith cultureIgnore
let indexCharInvariantCultureOf = indexOfCharWith invariant
let indexCharInvariantCultureIgnoreCaseOf = indexOfCharWith invariantIgnore

let indexOfWith (comparison: System.StringComparison) (segment: string) (str: string) =
    str.IndexOf(segment, comparison)

let indexOf = indexOfWith ordinal
let indexIgnoreCaseOf = indexOfWith ordinalIgnore
let indexCurrentCultureOf = indexOfWith culture
let indexCurrentCultureIgnoreCaseOf = indexOfWith cultureIgnore
let indexInvariantCultureOf = indexOfWith invariant
let indexInvariantCultureIgnoreCaseOf = indexOfWith invariantIgnore

let indexOfAnyChar (chars: char[]) (str: string) = str.IndexOfAny(chars)


// LastIndexOf

let lastIndexOfChar (ch: char) (str: string) = str.LastIndexOf(ch)

let lastIndexOfWith (comparison: System.StringComparison) (segment: string) (str: string) =
    str.LastIndexOf(segment, comparison)

let lastIndexOf = lastIndexOfWith ordinal
let lastIndexIgnoreCaseOf = lastIndexOfWith ordinalIgnore
let lastIndexCurrentCultureOf = lastIndexOfWith culture
let lastIndexCurrentCultureIgnoreCaseOf = lastIndexOfWith cultureIgnore
let lastIndexInvariantCultureOf = lastIndexOfWith invariant
let lastIndexInvariantCultureIgnoreCaseOf = lastIndexOfWith invariantIgnore

let lastIndexOfAnyChar (chars: char[]) (str: string) = str.LastIndexOfAny(chars)


// Padding

let padLeftWith (paddingChar: char) (totalWidth: int) (str: string) = str.PadLeft(totalWidth, paddingChar)

let padLeft (totalWidth: int) (str: string) = str.PadLeft(totalWidth)

let padRightWith (paddingChar: char) (totalWidth: int) (str: string) = str.PadRight(totalWidth, paddingChar)

let padRight (totalWidth: int) (str: string) = str.PadRight(totalWidth)


// Insert, Remove, SubString

let insertAt (index: int) (segment: string) (str: string) = str.Insert(index, segment)

let removeCountFrom (count: int) (index: int) (str: string) = str.Remove(index, count)

let removeFrom (index: int) (str: string) = str.Remove(index)

let subStringFrom startIndex length (str: string) = str.Substring(startIndex, length)

let subString startIndex (str: string) = str.Substring(startIndex)


// Replace

let replaceChar (oldChar: char) (newChar: char) (str: string) = str.Replace(oldChar, newChar)

let replaceWith (comparison: System.StringComparison) (oldSegment: string) (newSegment: string) (str: string) =
    str.Replace(oldSegment, newSegment, comparison)

let replace = replaceWith ordinal
let replaceIgnoreCase = replaceWith ordinalIgnore
let replaceCurrentCulture = replaceWith culture
let replaceCurrentCultureIgnoreCase = replaceWith cultureIgnore
let replaceInvariantCulture = replaceWith invariant
let replaceInvariantCultureIgnoreCase = replaceWith invariantIgnore


// Split

let internal noSplitOptions = System.StringSplitOptions.None
let internal trimEntries = System.StringSplitOptions.TrimEntries
let internal removeEmptyEntries = System.StringSplitOptions.RemoveEmptyEntries


let splitByChars (separators: char array) (str: string) = str.Split(separators)
let splitMaxCountByChars (count: int) (separators: char array) (str: string) = str.Split(separators, count)

let splitByCharsWithOptions (options: System.StringSplitOptions) (separators: char array) (str: string) =
    str.Split(separators, options)

let splitByCharsTrimmed = splitByCharsWithOptions trimEntries
let splitByCharsNonEmpty = splitByCharsWithOptions removeEmptyEntries
let splitByCharsClean = splitByCharsWithOptions (removeEmptyEntries ||| trimEntries)


let splitByChar separator = splitByChars [| separator |]
let splitMaxCountByChar count separator = splitMaxCountByChars count [| separator |]

let splitByCharWithOptions options separator = splitByCharsWithOptions options [| separator |]
let splitByCharTrimmed separator = splitByCharsTrimmed [| separator |]
let splitByCharNonEmpty separator = splitByCharsNonEmpty [| separator |]
let splitByCharClean separator = splitByCharsClean [| separator |]


let splitByWithOptions (options: System.StringSplitOptions) (separators: string array) (str: string) =
    str.Split(separators, options)

let splitBy = splitByWithOptions noSplitOptions
let splitByTrimmed = splitByWithOptions trimEntries
let splitByNonEmpty = splitByWithOptions removeEmptyEntries
let splitByClean = splitByWithOptions (removeEmptyEntries ||| trimEntries)


let split separator = splitBy [| separator |]

let splitWithOptions options separator = splitByWithOptions options [| separator |]
let splitTrimmed separator = splitByTrimmed [| separator |]
let splitNonEmpty separator = splitByNonEmpty [| separator |]
let splitClean separator = splitByClean [| separator |]


// StartsWith, EndsWith

let startsWithChar (ch: char) (str: string) = str.StartsWith(ch)

let startsWithOption (comparison: System.StringComparison) (segment: string) (str: string) =
    str.StartsWith(segment, comparison)

let startsWith = startsWithOption ordinal
let startsWithIgnoreCase = startsWithOption ordinalIgnore
let startsWithCurrentCulture = startsWithOption culture
let startsWithCurrentCultureIgnoreCase = startsWithOption cultureIgnore
let startsWithInvariantCulture = startsWithOption invariant
let startsWithInvariantCultureIgnoreCase = startsWithOption invariantIgnore

let endsWithChar (ch: char) (str: string) = str.EndsWith(ch)

let endsWithOption (comparison: System.StringComparison) (segment: string) (str: string) =
    str.EndsWith(segment, comparison)

let endsWith = endsWithOption ordinal
let endsWithIgnoreCase = endsWithOption ordinalIgnore
let endsWithCurrentCulture = endsWithOption culture
let endsWithCurrentCultureIgnoreCase = endsWithOption cultureIgnore
let endsWithInvariantCulture = endsWithOption invariant
let endsWithInvariantCultureIgnoreCase = endsWithOption invariantIgnore


// ToCharArray

let toCharArray (str: string) = str.ToCharArray()


// ToLower, ToUpper

let currentCulture() = System.Globalization.CultureInfo.CurrentCulture
let currentUICulture() = System.Globalization.CultureInfo.CurrentUICulture
let invariantCulture() = System.Globalization.CultureInfo.InvariantCulture


let toLower (str: string) = str.ToLower()
let toLowerWith culture (str: string) = str.ToLower(culture)
let toLowerCurrentCulture str = toLowerWith (System.Globalization.CultureInfo.CurrentCulture) str
let toLowerCurrentUICulture str = toLowerWith (System.Globalization.CultureInfo.CurrentUICulture) str
let toLowerInvariant (str: string) = str.ToLowerInvariant()


let toUpper (str: string) = str.ToUpper()
let toUpperWith culture (str: string) = str.ToUpper(culture)
let toUpperCurrentCulture str = toUpperWith (System.Globalization.CultureInfo.CurrentCulture) str
let toUpperCurrentUICulture str = toUpperWith (System.Globalization.CultureInfo.CurrentUICulture) str
let toUpperInvariant (str: string) = str.ToUpperInvariant()


// Trim, TrimStart, TrimEnd

let trim (str: string) = str.Trim()
let trimByChars (chars: char array) (str: string) = str.Trim(chars)
let trimByChar ch = trimByChars [| ch |]

let trimStart (str: string) = str.TrimStart()
let trimStartByChars (chars: char array) (str: string) = str.TrimStart(chars)
let trimStartByChar ch = trimStartByChars [| ch |]

let trimEnd (str: string) = str.TrimEnd()
let trimEndByChars (chars: char array) (str: string) = str.TrimEnd(chars)
let trimEndByChar ch = trimEndByChars [| ch |]
