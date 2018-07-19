using System;
using System.Windows.Forms;

namespace BettingParlor_Refactor
{
    /// <summary>
    /// Extension of <see cref="Dog"/> class.
    /// Contains all methods used to move pictureBoxes on the form.
    /// </summary>
    /// <seealso cref="Dog"/>
    class GreyHound : Dog
    {
        /// <summary>
        /// Initializes the fields properly.
        /// </summary>
        /// <param name="raceTrackLength">Length of the picturebox on the form which displays race track.</param>
        /// <param name="myPictureBox">PictureBox of dog which object is initialized.</param>
        /// <param name="randomizer">Object of Random class, used to draw random numbers.</param>
        public GreyHound(int raceTrackLength,PictureBox myPictureBox,Random randomizer)
        {
            this.raceTrackLength = raceTrackLength;
            this.myPictureBox = myPictureBox;
            this.randomizer = randomizer;
        }

        /// <summary>
        /// Moves dog on <see cref="FormServer"/>.
        /// Movement is totaly random. Every dog got same chances to win the race.
        /// Previous performance does not affect further races.
        /// </summary>
        /// <returns>
        /// True if dog has reached the end of the raceTrack (won the race)
        /// False if his position is not equal to end of the race track.</returns>
        /// <remarks> THIS MOVEMENT IS RANDOM ! </remarks>
        public bool Run()
        {
            location = randomizer.Next(1,4);
            myPictureBox.Left += location;
        
            if (myPictureBox.Left >= raceTrackLength)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Moves dogs on client form.
        /// Used in <see cref="FormClient"/> to move dogs not randomly.
        /// Updates position of specific dog on client form based on location send by server.
        /// </summary>
        /// <remarks> THIS MOVEMENT IS NOT RANDOM ! </remarks>
        /// <param name="locationOnServerForm">Contains location of specific dog on server form.</param>
        public void RunOnClientForm(int locationOnServerForm)
        {
            myPictureBox.Left += locationOnServerForm;
        }

        /// <summary>
        /// Sets dog location to default and his pictureBox position to the beginning of race track.
        /// </summary>
        public override void TakeStartingPosition()
        {
            location = 0;
            myPictureBox.Left = 0;
        }
    }
}
