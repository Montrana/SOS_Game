using SOS_Game;

namespace SOS_Game.xUnit
{
    // Minimal enums used in these tests. Remove if real enums exist in your project and use those instead.
    public enum GameMode { Simple, General }
    public enum Letter { S, O }

    // Minimal DTO used in tests. Replace with your actual options type.
    public class GameOptions
    {
        public int Size { get; set; }
        public GameMode Mode { get; set; }
    }

    public class SOSUnitTests
    {
        // NOTE: Replace 'Game' with your actual game implementation type.
        private dynamic CreateGameWithOptions(int size, GameMode mode)
        {
            GameScreen screen = new GameScreen();

            
            
            // If your Game has a constructor: return new Game(new GameOptions{ Size = size, Mode = mode });
            // If your Game uses StartNewGame: var g = new Game(); g.StartNewGame(new GameOptions{...}); return g;
            // Using dynamic here to keep test file adaptable; replace dynamic+reflection with real types.
            var options = new GameOptions { Size = size, Mode = mode };
            // Attempt constructor first (common pattern). If your class differs, replace this line.
            var gameType = typeof(object); // placeholder so compile-time errors don't occur in this example file.
            // In a real project, remove dynamic and call your real constructor or factory.
            return new GameScreen(); // Replace with "new Game(options)" in your codebase.
        }

        // -----------------------
        // Tests begin here
        // -----------------------

        [Fact]
        public void AC_3_1_StartGame_WithSelectedModeAndBoardSize_StartsGameWithThoseSettings()
        {
            // Arrange
            var size = 5;
            var mode = GameMode.Simple;
            var game = CreateGameWithOptions(size, mode);

            // Act
            // If your CreateGameWithOptions already started the game via constructor, skip StartNewGame.
            // Otherwise call: game.StartNewGame(new GameOptions{ Size = size, Mode = mode });
            // For the fake we assume constructor started it.

            // Assert
            Assert.True(game.IsStarted, "Game should be started after creating/starting with options.");
            Assert.Equal(size, game.Board.Rows, "Board should have the requested number of rows.");
            Assert.Equal(size, game.Board.Columns, "Board should have the requested number of columns.");
            Assert.Equal(mode, game.Mode, "Game mode should match the requested mode.");
        }

        [Fact]
        public void AC_4_1_ConfirmSelection_PlacesLetterAtSelectedSquare()
        {
            // Arrange
            var game = CreateGameWithOptions(3, GameMode.Simple);

            // Select letter 'S' then confirm at (0,0)
            game.SelectLetter(Letter.S);

            // Act
            game.ConfirmMove(0, 0);

            // Assert
            var cellValue = game.Board.CellAt(0, 0).Value;
            Assert.NotNull(cellValue);
            Assert.Equal("S", (string)cellValue, true);
        }

        [Fact]
        public void AC_4_2_SelectingS_NextMovePlacesS()
        {
            // Arrange
            var game = CreateGameWithOptions(3, GameMode.Simple);

            // Act
            game.SelectLetter(Letter.S);
            game.ConfirmMove(1, 1);

            // Assert
            var cellValue = game.Board.CellAt(1, 1).Value;
            Assert.NotNull(cellValue);
            Assert.Equal("S", (string)cellValue, true);
        }

        [Fact]
        public void AC_4_3_SelectingO_NextMovePlacesO()
        {
            // Arrange
            var game = CreateGameWithOptions(3, GameMode.Simple);

            // Act
            game.SelectLetter(Letter.O);
            game.ConfirmMove(2, 2);

            // Assert
            var cellValue = game.Board.CellAt(2, 2).Value;
            Assert.NotNull(cellValue);
            Assert.Equal("O", (string)cellValue, true);
        }
    }
}