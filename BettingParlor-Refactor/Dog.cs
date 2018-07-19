using System;
using System.Windows.Forms;

namespace BettingParlor_Refactor
{
    /// <summary>
    /// Provides base fields and methods which are used to properly handle dog pictureBoxes on the form.
    /// </summary>
    abstract class Dog
    {
        /// <summary>
        /// Length of the whole track.(length of the raceTrackPictureBox substracted by the length of dog pictureBox).
        /// </summary>
        protected int raceTrackLength;

        /// <summary>
        /// PictureBox on form which reperesents given dog.
        /// </summary>
        protected PictureBox myPictureBox;

        /// <summary>
        /// Current pictureBox location on the raceTrack.
        /// </summary>
        protected int location = 0;

        /// <summary>
        /// This object is stored in class because all objects have to draw random numbers from one generator.
        /// </summary>
        /// <remarks>Random instance is created on server and passed to each dog object when form is initialized.</remarks>
        protected Random randomizer;                   

        /// <summary>
        /// Returns current location of the dog on form.
        /// </summary>
        /// <remarks>Getter for accessing every single dog location on server form to pass it to clients.</remarks>
        public int GetLocation => location;             

        /// <summary>
        /// Resets position of current <see cref="myPictureBox"/> on the form to default.
        /// </summary>
        /// <remarks> Used after the race has finished to reset postion of each dog to default.</remarks>
        abstract public void TakeStartingPosition();   
    }
}
