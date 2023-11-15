# StringExtensions.HasValue method (1 of 3)

Checks whether the given string contains an actual value, not allowing empty or whitespace values.

```csharp
public static bool HasValue(this string? input)
```

| parameter | description |
| --- | --- |
| input | The string to test. |

## Return Value

`true` if the string has a value; otherwise, `false`.

## See Also

* class [StringExtensions](../StringExtensions.md)
* namespace [TinyHelpers.Extensions](../../TinyHelpers.md)

---

# StringExtensions.HasValue method (2 of 3)

Checks whether the given string contains an actual value, allowing to specify if permitting empty strings, and treating whitespace strings as empty.

```csharp
public static bool HasValue(this string? input, bool allowEmptyString)
```

| parameter | description |
| --- | --- |
| input | The string to test. |
| allowEmptyString | `true` to allow empty string, `false` otherwise. |

## Return Value

`true` if the string has a value; otherwise, `false`.

## See Also

* class [StringExtensions](../StringExtensions.md)
* namespace [TinyHelpers.Extensions](../../TinyHelpers.md)

---

# StringExtensions.HasValue method (3 of 3)

Checks whether the given string contains an actual value, allowing to specify if permitting empty strings and if treating whitespace strings as empty.

```csharp
public static bool HasValue(this string? input, bool allowEmptyString, bool whiteSpaceAsEmpty)
```

| parameter | description |
| --- | --- |
| input | The string to test. |
| allowEmptyString | `true` to allow empty string, `false` otherwise. |
| whiteSpaceAsEmpty | `true` if whitespace should be considered as empty string, `false` otherwise. |

## Return Value

`true` if the string has a value; otherwise, `false`.

## See Also

* class [StringExtensions](../StringExtensions.md)
* namespace [TinyHelpers.Extensions](../../TinyHelpers.md)

<!-- DO NOT EDIT: generated by xmldocmd for TinyHelpers.dll -->