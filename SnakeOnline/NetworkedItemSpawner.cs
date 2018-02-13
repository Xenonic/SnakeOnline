﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeOnline
{
    class NetworkedItemSpawner : ItemSpawner
    {
        private SnakeOnlineServer.ServerOutput ServerOutHandler;

        public override bool Initialize(SnakeOnlineServer.ServerInput ServerInput, World WorldInst)
        {
            return false;
        }

        public override bool Initialize(SnakeOnlineServer.ServerOutput ServerOut, World WorldInst)
        {
            ServerOutHandler = ServerOut;

            this.WorldInst = WorldInst;

            return true;
        }

        // Disabled
        public override void SpawnNew()
        {
            return;
        }

        public override void NetworkUpdate()
        {
            base.NetworkUpdate();

            int Row, Column;

            ServerOutHandler.GetItemSpawn(out Row, out Column);

            WorldInst.Set(2, Row, Column);
        }
    }
}
