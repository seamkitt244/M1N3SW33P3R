using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace M1N3SW33P3R
{
    class Blocks
    {/// <summary>
     /// class for block objects, the squares which make up the games grid
     /// </summary>
        private const double ratioOfMinesToSize = 0.1;
        public List<Blocks> blocksList = new List<Blocks>();
        public List<Button> buttonList = new List<Button>();
        public int blockX, blockY, numMines, numFlags;
        public Boolean mine, clicked, flaged;

        public Blocks(int _blockX, int _blockY, int _numMines, int _numFlags, Boolean _mine, Boolean _clicked, Boolean _flaged)//constructor method
        {
            blockX = _blockX;//x coord of block
            blockY = _blockY;//y coord of block
            numMines = _numMines;//number of mines in a 3x3 square around the block
            numFlags = _numFlags;// number of flags in a 3x3 square
            mine = _mine;//if the block is a mine or not
            clicked = _clicked;// if thge block has been clicked or not
            flaged = _flaged;
        }
    } 
}
