namespace Super_Solar_System.Database.Migrations
{
    using Super_Solar_System.Entities;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Super_Solar_System.Database.SunContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Super_Solar_System.Database.SunContext context)
        {
            // 1 ================================ Habitants
            Habitant H1 = new Habitant() { Id = 1, Species = "Venisians" };
            Habitant H2 = new Habitant() { Id = 2, Species = "Terrans" };
            Habitant H3 = new Habitant() { Id = 3, Species = "Neptunians" };
            Habitant H4 = new Habitant() { Id = 4, Species = "Martians" };
            Habitant H5 = new Habitant() { Id = 5, Species = "Mercurians" };
            Habitant H6 = new Habitant() { Id = 6, Species = "Uranians" };
            Habitant H7 = new Habitant() { Id = 7, Species = "Jupiterrans" };
            Habitant H8 = new Habitant() { Id = 8, Species = "Saturnians" };
            Habitant H9 = new Habitant() { Id = 9, Species = "Plutonians" };
            context.Habitants.AddOrUpdate(x => x.Species, H1, H2, H3, H4, H5, H6, H7, H8, H9);
            context.SaveChanges();

            // 2 ================================ Moons
            Moon M1 = new Moon() { Id = 1, Name = "Moon",       Distance = 31012, Radius = 2312, Image= "images\\Moon.jpg" };
            Moon M2 = new Moon() { Id = 2, Name = "Phobos",     Distance = 22451, Radius = 1228, Image= "images\\Phobos.jpg" };
            Moon M3 = new Moon() { Id = 3, Name = "Deimos",     Distance = 46654, Radius = 1468, Image= "images\\Deimos.jpg" };
            Moon M4 = new Moon() { Id = 4, Name = "Io",         Distance = 65654, Radius = 6541, Image= "images\\Io.jpg" };
            Moon M5 = new Moon() { Id = 5, Name = "Europa",     Distance = 49978, Radius = 1496, Image= "images\\Europa.jpg" };
            Moon M6 = new Moon() { Id = 6, Name = "Ganymede",   Distance = 71321, Radius = 7154, Image= "images\\Ganymede.jpg" };
            Moon M7 = new Moon() { Id = 7, Name = "Callisto",   Distance = 71321, Radius = 6413, Image= "images\\Callisto.jpg" };
            Moon M8 = new Moon() { Id = 8, Name = "Mimas",      Distance = 16456, Radius = 7563, Image= "images\\Mimas.jpg" };
            Moon M9 = new Moon() { Id = 9, Name = "Enceladus",  Distance = 71321, Radius = 8521, Image= "images\\Enceladus.jpg" };
            Moon M10 = new Moon() { Id = 10, Name = "Tethys",   Distance = 15677, Radius = 3564, Image= "images\\Tethys.jpg" };
            Moon M11 = new Moon() { Id = 11, Name = "Dione",    Distance = 12345, Radius = 1998, Image= "images\\Dione.jpg" };
            Moon M12 = new Moon() { Id = 12, Name = "Rhea",     Distance = 24577, Radius = 3457, Image= "images\\Rhea.jpg" };
            Moon M13 = new Moon() { Id = 13, Name = "Titan",    Distance = 13478, Radius = 8569, Image= "images\\Titan.jpg" };
            Moon M14 = new Moon() { Id = 14, Name = "Hyperion", Distance = 13435, Radius = 3654, Image= "images\\Hyperion.jpg" };
            Moon M15 = new Moon() { Id = 15, Name = "Iapetus",  Distance = 16799, Radius = 1425, Image= "images\\Iapetus.jpg" };
            Moon M16 = new Moon() { Id = 16, Name = "Miranda",  Distance = 71321, Radius = 1133, Image= "images\\Miranda.jpg" };
            Moon M17 = new Moon() { Id = 17, Name = "Ariel",    Distance = 71321, Radius = 1252, Image= "images\\Ariel.jpg" };
            Moon M18 = new Moon() { Id = 18, Name = "Umbriel",  Distance = 71321, Radius = 8541, Image= "images\\Umbriel.jpg" };
            Moon M19 = new Moon() { Id = 19, Name = "Titania",  Distance = 18564, Radius = 6587, Image= "images\\Titania.jpg" };
            Moon M20 = new Moon() { Id = 20, Name = "Oberon",   Distance = 36987, Radius = 5423, Image= "images\\Oberon.jpg" };
            Moon M21 = new Moon() { Id = 21, Name = "Triton",   Distance = 18521, Radius = 3215, Image= "images\\Triton.jpg" };

            context.Moons.AddOrUpdate(x => x.Name, M1, M2, M3, M4, M5, M6, M7, M8, M9, M10,
                                                    M11, M12, M13, M14, M15, M16, M17, M18, M19, M20, M20);
            context.SaveChanges();

            // 3 ================================ Planets
            Planet P1 = new Planet() { Id = 1, Name = "Mercury", Distance = 57909000, Radius = 4879, Image = "images\\Mercury.jpg" };
            P1.Habitants.Add(H5);
            P1.Habitants.Add(H6);
            P1.Habitants.Add(H9);
            Planet P2 = new Planet() { Id = 2, Name = "Venus", Distance = 100160000, Radius = 12103, Image = "images\\Venus.jpg" };
            P2.Habitants.Add(H1);
            P2.Habitants.Add(H2);
            Planet P3 = new Planet() { Id = 3, Name = "Earth", Distance = 149600000, Radius = 12756, Image = "images\\Earth.png" };
            P3.Moons.Add(M1);
            P3.Habitants.Add(H2);
            Planet P4 = new Planet() { Id = 4, Name = "Mars", Distance = 227990000, Radius = 6792, Image = "images\\Mars.jpg" };
            P4.Moons.Add(M2);
            P4.Moons.Add(M3);
            P4.Habitants.Add(H4);
            Planet P5 = new Planet() { Id = 5, Name = "Jupiter", Distance = 778360000, Radius = 142984, Image = "images\\Jupiter.jpg" };
            P5.Moons.Add(M4);
            P5.Moons.Add(M5);
            P5.Moons.Add(M6);
            P5.Moons.Add(M7);
            P5.Habitants.Add(H7);
            P5.Habitants.Add(H8);
            P5.Habitants.Add(H9);
            Planet P6 = new Planet() { Id = 6, Name = "Saturn", Distance = 1433500000, Radius = 120536, Image = "images\\Saturn.jpg" };
            P6.Moons.Add(M8);
            P6.Moons.Add(M9);
            P6.Moons.Add(M10);
            P6.Moons.Add(M11);
            P6.Moons.Add(M12);
            P6.Moons.Add(M13);
            P6.Moons.Add(M14);
            P6.Moons.Add(M15);
            P6.Habitants.Add(H7);
            P6.Habitants.Add(H8);
            P6.Habitants.Add(H9);
            P6.Habitants.Add(H3);
            Planet P7 = new Planet() { Id = 7, Name = "Uranus", Distance = 2872400000, Radius = 51118, Image = "images\\Uranus.jpg" };
            P7.Moons.Add(M16);
            P7.Moons.Add(M17);
            P7.Moons.Add(M18);
            P7.Moons.Add(M19);
            P7.Moons.Add(M20);
            P7.Habitants.Add(H7);
            P7.Habitants.Add(H8);
            P7.Habitants.Add(H1);
            P7.Habitants.Add(H6);
            Planet P8 = new Planet() { Id = 8, Name = "Neptune", Distance = 4498400000, Radius = 49528, Image = "images\\Neptune.jpg" };
            P4.Moons.Add(M21);
            P4.Habitants.Add(H3);

            context.Planets.AddOrUpdate(m => m.Name, P1, P2, P3, P4, P5, P6, P7, P8);
            context.SaveChanges();
        }
    }
}
