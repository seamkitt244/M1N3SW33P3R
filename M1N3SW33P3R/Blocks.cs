using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace M1N3SW33P3R
{
    class Blocks
    {
        private const double ratioOfMinesToSize = 0.1;
        public static List<Blocks> blocksList = new List<Blocks>();
        private GameScreen game;
        private int winningNumberOfReveals;
        private int revealedItems;
        public int x, y, size,numMines;
        public Boolean mine,clicked;
        public Blocks(int _size,int _blockX, int _blockY, int _numMines,Boolean  _mine, Boolean _clicked)//constructor method
        {
            size = _size;
            x = _blockX;
            y = _blockY;
            numMines = _numMines;
            mine = _mine;
            clicked = _clicked;
        }        
        //public static void GridCreate(int size,int blockX,int blockY, Boolean mine,Boolean clicked)
        //{   
        //    for (int i = 0; i < StartMenu.boardSize * StartMenu.boardSize; i++)
        //    {
        //        if (blockX > GameScreen.blockXOrg + size * StartMenu.boardSize - 1)
        //        {
        //            blockX = GameScreen.blockXOrg;
        //            blockY =  blockY+ size;
        //        }
        //        Blocks tempBlock = new Blocks(size, blockX, blockY,mine,clicked);
        //        blocksList.Add(tempBlock);
        //        blockX = blockX + size;
        //    }
        //}
    }

}
