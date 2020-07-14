﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyPortal.Logic.Models.Data
{
    public class TreeNode
    {
        public string Id { get; set; }
        public string Parent { get; set; }
        public string Text { get; set; }
        public string Icon { get; set; }
        public TreeNodeState State { get; set; }
        public bool Container { get; set; }

        public static TreeNode CreateRoot(string name)
        {
            return new TreeNode
            {
                Id = "#",
                Text = name,
                State = new TreeNodeState
                {
                    Opened = true,
                    Disabled = false,
                    Selected = false
                }
            };
        }
    }
}