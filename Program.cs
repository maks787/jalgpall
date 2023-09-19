using jalgpall;

Team t1 = new Team("esimene");
Player p1 = new Player("Mängija");
t1.AddPlayer(p1);
Player p2 = new Player("Mängija2");
t1.AddPlayer(p2);


Team t2 = new Team("Teine");
Player p3 = new Player("Mängija");
t1.AddPlayer(p1);
Player p4 = new Player("Mängija2");
t1.AddPlayer(p2);

Stadium s = new Stadium(400, 300);

Game g=new Game(t1,t2,s);
g.Start();
﻿
