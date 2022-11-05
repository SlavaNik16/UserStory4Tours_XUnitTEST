using FluentAssertions;
using FluentAssertions.Extensions;
using UserStory4Tours.models;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace xUnitTestTourse
{
    public class TourseTest
    {
        public LibTourse.Lib cal = new LibTourse.Lib();

        [Fact]
        public void AddButton()
        {
            var item = 1.March(2022).At(20, 30).AsLocal();
            var result = cal.Add(item);
            var items = cal.GetList();
            //Check if the date added to the list matches,
            //with the date we added.
            result.Should().Be(1.March(2022).At(20, 30));
            //Check the list so that it is not empty
            items.Should().NotBeEmpty()
                .And.HaveCount(1)//Contained 1 element
                .And.ContainSingle(x => x == item);//and coincided with this element(item)
        }

        [Fact]
        public void ChangeButton()
        {
            var itemStart = 1.March(2022).At(20, 30).AsLocal();
            var itemFinal = 4.October(2023).At(5, 59).AsLocal();
            cal.Add(itemStart);
            var result = cal.GetList();
            result[0] = itemFinal;
            //Replace the item we added in the list (has index 0)
            //with another date
            result.Should().NotBeEmpty()
                .And.HaveCount(1)
                .And.ContainSingle(x => x == itemFinal);
        }

        [Fact]
        public void DeleteButton()
        {
            var item = 1.March(2022).At(20, 30).AsLocal();
            cal.Add(item);
            var result = cal.GetList();
            result.Should().NotBeEmpty()
                .And.HaveCount(1)
                .And.ContainSingle(x => x == item);

            result.Remove(item);//Deleting an element
            // We make a test that there is nothing in the list.
            result.Should().BeEmpty()
                .And.HaveCount(0);
        }
        [Fact]
        public void CountEnumDirection()
        { 
            var result = cal.FillDirection();
            //Check if no one has added a new element to our Enum Direction
            //result.Should().Be(6);
            Assert.Equal(6, result);
        }
        [Theory]
        //(NumberNight * NumberVac *  CostVac) + Surcharges
        [InlineData(2, 3, 4, 5, 29)] //true
        [InlineData(2, 3, 4, 5, 30)] //false
        [InlineData(5, 5, 5, 5, 130)]//true
        public void SumAll(int NumberNight,int NumberVac, int CostVac, int Surcharges,int result)
        {
            //Checking whether the total amount was calculated correctly in the DataGridView
            var sum = cal.Sum(NumberNight, NumberVac, CostVac, Surcharges);
            Assert.Equal(sum, result);
        }

    }
}