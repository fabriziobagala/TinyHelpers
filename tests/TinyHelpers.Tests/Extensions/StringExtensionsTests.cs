﻿using TinyHelpers.Extensions;

namespace TinyHelpers.Tests.Extensions;

public class StringExtensionsTests
{
    [Theory]
    [InlineData("Marco", false, false)]
    [InlineData("Marco", true, false)]
    [InlineData("Marco", false, true)]
    [InlineData("Marco", true, true)]
    [InlineData("", true, false)]
    [InlineData("", true, true)]
    [InlineData(" ", true, false)]
    [InlineData(" ", true, true)]
    [InlineData(" ", false, false)]
    public void HasValue_ValidString_Should_Return_True(string? input, bool allowEmptyString, bool whiteSpaceAsEmpty)
    {
        // Arrange

        // Act
        var hasValue = input.HasValue(allowEmptyString, whiteSpaceAsEmpty);

        // Assert
        Assert.True(hasValue);
    }

    [Theory]
    [InlineData("", false, false)]
    [InlineData("", false, true)]
    [InlineData(" ", false, true)]
    [InlineData(null, false, false)]
    [InlineData(null, true, false)]
    [InlineData(null, false, true)]
    [InlineData(null, true, true)]
    public void HasValue_InvalidString_Should_Return_False(string? input, bool allowEmptyString, bool whiteSpaceAsEmpty)
    {
        // Arrange

        // Act
        var hasValue = input.HasValue(allowEmptyString, whiteSpaceAsEmpty);

        // Assert
        Assert.False(hasValue);
    }

    [Theory]
    [InlineData(@"\Welcome\world", @"\welcome", @"\hello", @"\hello\world")]
    [InlineData(@"\Welcome\world", @"\WELCOME", @"\hello", @"\hello\world")]
    [InlineData(@"\Welcome\world", @".*", @"\hello", @"\Welcome\world")]
    public void ReplaceIgnoreCase_Should_Replace_Ignoring_Case(string input, string pattern, string replacement, string expected)
    {
        // Arrange

        // Act
        var newString = input.ReplaceIgnoreCase(pattern, replacement);

        // Assert
        Assert.Equal(expected, newString);
    }

    [Theory]
    [InlineData(null, "")]
    [InlineData("", "")]
    [InlineData("m", "M")]
    [InlineData("marco", "Marco")]
    [InlineData("mARCo", "MARCo")]
    [InlineData("42", "42")]
    public void FirstCharToUpper(string? input, string expected)
    {
        // Arrange

        // Act
        var newString = input!.FirstCharToUpper();

        // Assert
        Assert.Equal(expected, newString);
    }
}