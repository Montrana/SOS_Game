using System;
using System.Windows.Forms;

namespace SOS_Game
{
    partial class GameScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridSizeLabel = new System.Windows.Forms.Label();
            this.blueS = new System.Windows.Forms.RadioButton();
            this.blueO = new System.Windows.Forms.RadioButton();
            this.redS = new System.Windows.Forms.RadioButton();
            this.redO = new System.Windows.Forms.RadioButton();
            this.gameGrid = new System.Windows.Forms.TableLayoutPanel();
            this.gridSizeNum = new System.Windows.Forms.MaskedTextBox();
            this.sizeWarning = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.simpleButton = new System.Windows.Forms.RadioButton();
            this.complexButton = new System.Windows.Forms.RadioButton();
            this.bluePlayer = new System.Windows.Forms.GroupBox();
            this.redPlayer = new System.Windows.Forms.GroupBox();
            this.sosGroup = new System.Windows.Forms.GroupBox();
            this.turnLabel = new System.Windows.Forms.Label();
            this.WinnerLabel = new System.Windows.Forms.Label();
            this.bluePlayer.SuspendLayout();
            this.redPlayer.SuspendLayout();
            this.sosGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridSizeLabel
            // 
            this.gridSizeLabel.AutoSize = true;
            this.gridSizeLabel.Location = new System.Drawing.Point(490, 9);
            this.gridSizeLabel.Name = "gridSizeLabel";
            this.gridSizeLabel.Size = new System.Drawing.Size(52, 13);
            this.gridSizeLabel.TabIndex = 4;
            this.gridSizeLabel.Text = "Grid Size:";
            this.gridSizeLabel.Click += new System.EventHandler(this.GridSizeLabel_Click);
            // 
            // blueS
            // 
            this.blueS.AutoSize = true;
            this.blueS.Checked = true;
            this.blueS.Location = new System.Drawing.Point(6, 19);
            this.blueS.Name = "blueS";
            this.blueS.Size = new System.Drawing.Size(59, 17);
            this.blueS.TabIndex = 7;
            this.blueS.TabStop = true;
            this.blueS.Text = "Human";
            this.blueS.UseVisualStyleBackColor = true;
            this.blueS.CheckedChanged += new System.EventHandler(this.BlueS_CheckedChanged);
            // 
            // blueO
            // 
            this.blueO.AutoSize = true;
            this.blueO.Location = new System.Drawing.Point(6, 42);
            this.blueO.Name = "blueO";
            this.blueO.Size = new System.Drawing.Size(70, 17);
            this.blueO.TabIndex = 1;
            this.blueO.TabStop = true;
            this.blueO.Text = "Computer";
            this.blueO.UseVisualStyleBackColor = true;
            this.blueO.CheckedChanged += new System.EventHandler(this.BlueO_CheckedChanged);
            // 
            // redS
            // 
            this.redS.AutoSize = true;
            this.redS.Checked = true;
            this.redS.Location = new System.Drawing.Point(6, 19);
            this.redS.Name = "redS";
            this.redS.Size = new System.Drawing.Size(59, 17);
            this.redS.TabIndex = 7;
            this.redS.TabStop = true;
            this.redS.Text = "Human";
            this.redS.UseVisualStyleBackColor = true;
            this.redS.CheckedChanged += new System.EventHandler(this.RedS_CheckedChanged);
            // 
            // redO
            // 
            this.redO.AutoSize = true;
            this.redO.Location = new System.Drawing.Point(6, 42);
            this.redO.Name = "redO";
            this.redO.Size = new System.Drawing.Size(70, 17);
            this.redO.TabIndex = 8;
            this.redO.TabStop = true;
            this.redO.Text = "Computer";
            this.redO.UseVisualStyleBackColor = true;
            this.redO.CheckedChanged += new System.EventHandler(this.RedO_CheckedChanged);
            // 
            // gameGrid
            // 
            this.gameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.gameGrid.Location = new System.Drawing.Point(191, 90);
            this.gameGrid.Name = "gameGrid";
            this.gameGrid.Size = new System.Drawing.Size(200, 100);
            this.gameGrid.TabIndex = 13;
            this.gameGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.gameGrid_Paint_1);
            // 
            // gridSizeNum
            // 
            this.gridSizeNum.Location = new System.Drawing.Point(548, 6);
            this.gridSizeNum.Mask = "00000";
            this.gridSizeNum.Name = "gridSizeNum";
            this.gridSizeNum.Size = new System.Drawing.Size(100, 20);
            this.gridSizeNum.TabIndex = 10;
            this.gridSizeNum.ValidatingType = typeof(int);
            this.gridSizeNum.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.GridSizeNum_MaskInputRejected);
            // 
            // sizeWarning
            // 
            this.sizeWarning.AutoSize = true;
            this.sizeWarning.ForeColor = System.Drawing.Color.Red;
            this.sizeWarning.Location = new System.Drawing.Point(545, 29);
            this.sizeWarning.Name = "sizeWarning";
            this.sizeWarning.Size = new System.Drawing.Size(113, 13);
            this.sizeWarning.TabIndex = 11;
            this.sizeWarning.Text = "Grid Size must be 3-10";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(296, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 12;
            this.startButton.Text = "New Game";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // simpleButton
            // 
            this.simpleButton.AutoSize = true;
            this.simpleButton.Checked = true;
            this.simpleButton.Location = new System.Drawing.Point(6, 19);
            this.simpleButton.Name = "simpleButton";
            this.simpleButton.Size = new System.Drawing.Size(87, 17);
            this.simpleButton.TabIndex = 15;
            this.simpleButton.TabStop = true;
            this.simpleButton.Text = "Simple Game";
            this.simpleButton.UseVisualStyleBackColor = true;
            this.simpleButton.CheckedChanged += new System.EventHandler(this.SimpleButton_CheckedChanged);
            // 
            // complexButton
            // 
            this.complexButton.AutoSize = true;
            this.complexButton.Location = new System.Drawing.Point(6, 42);
            this.complexButton.Name = "complexButton";
            this.complexButton.Size = new System.Drawing.Size(96, 17);
            this.complexButton.TabIndex = 16;
            this.complexButton.TabStop = true;
            this.complexButton.Text = "Complex Game";
            this.complexButton.UseVisualStyleBackColor = true;
            this.complexButton.CheckedChanged += new System.EventHandler(this.ComplexButton_CheckedChanged);
            // 
            // bluePlayer
            // 
            this.bluePlayer.Controls.Add(this.blueS);
            this.bluePlayer.Controls.Add(this.blueO);
            this.bluePlayer.Location = new System.Drawing.Point(48, 90);
            this.bluePlayer.Name = "bluePlayer";
            this.bluePlayer.Size = new System.Drawing.Size(99, 115);
            this.bluePlayer.TabIndex = 17;
            this.bluePlayer.TabStop = false;
            this.bluePlayer.Text = "Blue Player";
            // 
            // redPlayer
            // 
            this.redPlayer.Controls.Add(this.redS);
            this.redPlayer.Controls.Add(this.redO);
            this.redPlayer.Location = new System.Drawing.Point(537, 90);
            this.redPlayer.Name = "redPlayer";
            this.redPlayer.Size = new System.Drawing.Size(111, 100);
            this.redPlayer.TabIndex = 18;
            this.redPlayer.TabStop = false;
            this.redPlayer.Text = "Red Player";
            // 
            // sosGroup
            // 
            this.sosGroup.Controls.Add(this.simpleButton);
            this.sosGroup.Controls.Add(this.complexButton);
            this.sosGroup.Location = new System.Drawing.Point(12, 12);
            this.sosGroup.Name = "sosGroup";
            this.sosGroup.Size = new System.Drawing.Size(135, 72);
            this.sosGroup.TabIndex = 19;
            this.sosGroup.TabStop = false;
            this.sosGroup.Text = "SOS";
            // 
            // turnLabel
            // 
            this.turnLabel.AutoSize = true;
            this.turnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnLabel.Location = new System.Drawing.Point(377, 12);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(98, 20);
            this.turnLabel.TabIndex = 21;
            this.turnLabel.Text = "Who\'s Turn?";
            this.turnLabel.Click += new System.EventHandler(this.turnLabel_Click);
            // 
            // WinnerLabel
            // 
            this.WinnerLabel.AutoSize = true;
            this.WinnerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WinnerLabel.Location = new System.Drawing.Point(178, 153);
            this.WinnerLabel.Name = "WinnerLabel";
            this.WinnerLabel.Size = new System.Drawing.Size(327, 73);
            this.WinnerLabel.TabIndex = 22;
            this.WinnerLabel.Text = "WINNER!!";
            this.WinnerLabel.Visible = false;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 418);
            this.Controls.Add(this.WinnerLabel);
            this.Controls.Add(this.turnLabel);
            this.Controls.Add(this.sosGroup);
            this.Controls.Add(this.redPlayer);
            this.Controls.Add(this.bluePlayer);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.sizeWarning);
            this.Controls.Add(this.gridSizeNum);
            this.Controls.Add(this.gameGrid);
            this.Controls.Add(this.gridSizeLabel);
            this.Name = "GameScreen";
            this.Text = "SOS Game";
            this.bluePlayer.ResumeLayout(false);
            this.bluePlayer.PerformLayout();
            this.redPlayer.ResumeLayout(false);
            this.redPlayer.PerformLayout();
            this.sosGroup.ResumeLayout(false);
            this.sosGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// Generates the grid with the textboxes inside that will be updated when clicked
        /// </summary>
        private void CreateGrid(int size)
        {
            float sizePercent = (float) 100 / size;
            this.gameGrid.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.gameGrid.ColumnCount = size;
            Console.WriteLine(sizePercent);

            //Sets the columns to be a percentage of the table size so that all columns are equal
            for (int c = 0; c < size; c++)
            {
                this.gameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, sizePercent));
            }
            
            this.gameGrid.Location = new System.Drawing.Point(179, 45);
            this.gameGrid.Margin = new System.Windows.Forms.Padding(0);
            this.gameGrid.Name = "gameGrid";

            this.gameGrid.RowCount = size;

            //Sets the rows to be a percentage of the table size so that all rows are equal
            for (int r = 0; r < size; r++) 
            {
                this.gameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, sizePercent));
            }

            for (int row = 0; row < gameGrid.RowCount; row++)
            {
                for (int col = 0; col < gameGrid.ColumnCount; col++)
                {
                    Label label = new Label();
                    label.Text = $""; // Set the desired text for the label
                    label.Dock = DockStyle.Fill;       // Make the label fill the cell
                    label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter; // Aligns the text to the center of the cell
                    label.SendToBack(); //sends the label to the back of the view, so that when clicking, it still registers the grid as being clicked
                    label.Click += new System.EventHandler(this.GridBoxLabel_Click); //Enable the clicking of the label to corespond with the clicking of the gridbox behind it

                    // Add the label to the TableLayoutPanel at the specified column and row
                    gameGrid.Controls.Add(label, col, row);
                }
            }

            this.gameGrid.Size = new System.Drawing.Size(318,318);
            this.gameGrid.TabIndex = 9;
            this.gameGrid.Click += new System.EventHandler(this.GameGrid_Click);
            this.gameGrid.CellPaint += new TableLayoutCellPaintEventHandler(this.GameGrid_CellPaint);
        }

        #endregion
        private System.Windows.Forms.RadioButton blueO;
        private System.Windows.Forms.Label gridSizeLabel;
        private System.Windows.Forms.RadioButton redS;
        private System.Windows.Forms.RadioButton blueS;
        private System.Windows.Forms.RadioButton redO;
        private System.Windows.Forms.TableLayoutPanel gameGrid;
        private System.Windows.Forms.MaskedTextBox gridSizeNum;
        private System.Windows.Forms.Label sizeWarning;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.RadioButton simpleButton;
        private System.Windows.Forms.RadioButton complexButton;
        private GroupBox bluePlayer;
        private GroupBox redPlayer;
        private GroupBox sosGroup;
        private Label turnLabel;
        private Label WinnerLabel;
    }
}

