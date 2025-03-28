using PathfinderSecondEdition.Grid;

namespace PathfinderSecondEditionTest
{
    public class GridPositionTest
    {
        [Fact]
        public void GridOperatorTest()
        {
            GridPosition gridPosition = new GridPosition(2, 2);

            GridPosition gridPosition2 = new GridPosition(2, 2);

            GridPosition gridPosition3 = gridPosition - gridPosition2;

            Assert.True(gridPosition == gridPosition2);
            Assert.False(gridPosition != gridPosition2);
            Assert.True(new GridPosition(0, 0) == gridPosition3);
        }
    }
}
