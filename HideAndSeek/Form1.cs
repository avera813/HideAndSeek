using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HideAndSeek
{
    public partial class Form1 : Form
    {
        int Moves;
        Location currentLocation;
        RoomWithDoor livingRoom, kitchen, hallway;
        Room diningRoom, stairs;
        RoomWithHidingPlace masterBedroom, secondBedroom, bathroom;
        OutsideWithDoor frontYard, backYard;
        OutsideWithHidingPlace garden, driveway;
        OutsideWithDoorHidingPlace balcony;
        Opponent opponent;

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            opponent = new Opponent(frontYard);
            ResetGame(false);
        }
        private void CreateObjects()
        {
            // Declare rooms and room types
            livingRoom = new RoomWithDoor("Living Room", "an antique carpet", "inside the closet", "an oak door with a brass handle");
            diningRoom = new Room("Dining Room", "a crystal chandelier");
            kitchen = new RoomWithDoor("Kitchen", "stainless steel appliances", "in the cabinet", "a screen door");
            stairs = new Room("Stairs", "a wooden bannister");
            hallway = new RoomWithDoor("Upstairs Hallway", "a picture of a dog", "in the closet", "french doors");
            masterBedroom = new RoomWithHidingPlace("Master Bedroom", "a large bed", "under the bed");
            secondBedroom = new RoomWithHidingPlace("Second Bedroom", "a small bed", "under the bed");
            bathroom = new RoomWithHidingPlace("Bathroom", "a sink and a toilet", "in the shower");
            frontYard = new OutsideWithDoor("Front Yard", false, "a heavy-looking oak door");
            backYard = new OutsideWithDoor("Back Yard", true, "a screen door");
            garden = new OutsideWithHidingPlace ("Garden", false, "inside the shed");
            driveway = new OutsideWithHidingPlace("Driveway", true, "in the garage");
            balcony = new OutsideWithDoorHidingPlace("Outside Balcony", false, "french doors", "under a tarp");

            // Declare exits
            livingRoom.Exits = new Location[] { diningRoom, stairs };
            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            kitchen.Exits = new Location[] { diningRoom };
            stairs.Exits = new Location[] { livingRoom, hallway };
            hallway.Exits = new Location[] { stairs, masterBedroom, secondBedroom, bathroom };
            masterBedroom.Exits = new Location[] { hallway };
            secondBedroom.Exits = new Location[] { hallway };
            bathroom.Exits = new Location[] { hallway };
            frontYard.Exits = new Location[] { backYard, garden, driveway };
            backYard.Exits = new Location[] { frontYard, garden, driveway };
            garden.Exits = new Location[] { frontYard, backYard };
            driveway.Exits = new Location[] { frontYard, backYard };
            balcony.Exits = new Location[] { };

            // Declare door locations
            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;
            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;
            hallway.DoorLocation = balcony;
            balcony.DoorLocation = hallway;
        }

        private void RedrawForm()
        {
            // Removing old exits
            exits.Items.Clear();

            if (currentLocation.Exits.Length > 0)
            {
                // Adding exits for new location to dropdown
                for (int i = 0; i < currentLocation.Exits.Length; ++i)
                {
                    exits.Items.Add(currentLocation.Exits[i].Name);
                }

                // Set dropdown to first item
                exits.SelectedIndex = 0;
                goHere.Visible = true;
                exits.Visible = true;
            }
            else
            {
                goHere.Visible = false;
                exits.Visible = false;
            }

            // Updating description text
            description.Text = currentLocation.Description + System.Environment.NewLine + "(move #" + Moves + ")";

            // Check if current location is a hiding place
            if (currentLocation is IHidingPlace)
            {
                IHidingPlace hidingPlace = currentLocation as IHidingPlace;

                // Update 'check' button text
                check.Text = "Check " + hidingPlace.HidingPlaceName;
                check.Visible = true;
            }
            else
            {
                check.Visible = false;
            }

            // Enable/disable 'Go through the door' button
            goThroughTheDoor.Visible = (currentLocation is IHasExteriorDoor) ? true : false;
        }

        private void ResetGame(bool gameOver)
        {
            // Display message if the game is over
            if (gameOver)
            {
                MessageBox.Show("You found me in " + Moves + " moves!");
                IHidingPlace foundLocation = currentLocation as IHidingPlace;
                description.Text = "You found your opponent in " + Moves + " moves! He was hiding " + foundLocation.HidingPlaceName + ".";
            }

            // Reset moves
            Moves = 0;

            // Reset form
            hide.Visible = true;
            goHere.Visible = false;
            check.Visible = false;
            goThroughTheDoor.Visible = false;
            exits.Visible = false;
        }

        private void MoveToANewLocation(Location newLocation)
        {
            // Record move count
            Moves++;

            // Updating current location
            currentLocation = newLocation;

            // Update form
            RedrawForm();
        }

        private void goHere_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[exits.SelectedIndex]);
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor hasDoor = currentLocation as IHasExteriorDoor;
            MoveToANewLocation(hasDoor.DoorLocation);
        }

        private void check_Click(object sender, EventArgs e)
        {
            Moves++;
            if (opponent.Check(currentLocation))
            {
                ResetGame(true);
            }
            else
            {
                RedrawForm();
            }
        }

        private void hide_Click(object sender, EventArgs e)
        {
            // Game starts now
            hide.Visible = false;
            for (int i = 1; i <= 10; ++i)
            {
                // Move opponent 10 times
                opponent.Move();

                // Display counting on text box
                description.Text = i + "...";

                // Sleep for 200ms
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);
            }

            // Display that the seeker is ready to search for the opponent
            description.Text = "Ready or not, here I come!";

            // Sleep for 500ms
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);

            // Make 'Go Here' button and dropdown visible
            goHere.Visible = true;
            exits.Visible = true;

            // Set the seeker to start from living room
            MoveToANewLocation(livingRoom);
        }
    }
}
