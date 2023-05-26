using Sayeed.NETCore.DataProtection.Tests.MockEntity;

namespace Sayeed.NETCore.DataProtection.Tests
{
    public class HelperTests
    {
        [Fact]
        public void HideSensativeProperties_InitializedWithDefaultConfiguration_HidesInformationProperly()
        {
            // Arrange
            Helper helper = new();
            Parent parent = new()
            {
                Name = "parent",
                HasPassword = true,
                Children = new List<ChildB>
                {
                    new () { Name = "name", AuthToken = "zxczxcxzc" },
                    new () { Name = "zxczcxxc", AuthToken = "abc" }
                },
                ParentPassword = "password",
                SingleChild = new()
                {
                    Name = "name",
                    Secret = "password",
                }
            };

            // Act
            helper.HideSensativeProperties(parent);

            // Assert
            Assert.NotNull(parent.Name);
            Assert.Null(parent.ParentPassword);
            Assert.NotNull(parent.SingleChild.Name);
            Assert.Null(parent.SingleChild.Secret);
            Assert.NotNull(parent.Children[0].Name);
            Assert.Null(parent.Children[0].AuthToken);
            Assert.NotNull(parent.Children[1].Name);
            Assert.Null(parent.Children[1].AuthToken);
        }

        [Fact]
        public void HideSensativeProperties_InitializedWithCustomSecretKeywords_HidesInformationProperly()
        {
            // Arrange
            string[] customKeywords = { "name", "uth" };
            Helper helper = new(customKeywords);
            Parent parent = new()
            {
                Name = "parent",
                HasPassword = true,
                Children = new List<ChildB>
                {
                    new () { Name = "name", AuthToken = "zxczxcxzc" },
                    new () { Name = "zxczcxxc", AuthToken = "abc" }
                },
                ParentPassword = "password",
                SingleChild = new()
                {
                    Name = "name",
                    Secret = "password",
                }
            };

            // Act
            helper.HideSensativeProperties(parent);

            // Assert
            Assert.Null(parent.Name);
            Assert.NotNull(parent.ParentPassword);
            Assert.Null(parent.SingleChild.Name);
            Assert.NotNull(parent.SingleChild.Secret);
            Assert.Null(parent.Children[0].Name);
            Assert.Null(parent.Children[0].AuthToken);
            Assert.Null(parent.Children[1].Name);
            Assert.Null(parent.Children[1].AuthToken);
        }

    }
}