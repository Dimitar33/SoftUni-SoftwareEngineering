// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
  //  using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class StageTests
    {
        [Test]
        public void AddPerformerAgeLessThan18()
        {

            Stage stage = new Stage();

            Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("Ivan", "Ivanov", 12)));


        }

        [Test]
        public void AddPerformerCorrect()
        {
            Performer singer = new Performer("ASD", "DSA", 21);
            Stage stage = new Stage();
            stage.AddPerformer(singer);

            Assert.AreEqual(1, stage.Performers.Count);
        }

        [Test]
        public void AddSongMustBeOver1Min()
        {

            Stage stage = new Stage();
            Assert.Throws<ArgumentException>(() => stage.AddSong(new Song("ASD", new TimeSpan(0, 0, 30))));

        }

        [Test]
        public void AddSongToPerformerWorkCorrect()
        {
            Performer singer = new Performer("Ivan", "Ivanov", 21);
            Song song = new Song("Song", new TimeSpan(0, 2, 30));
            Stage stage = new Stage();
            stage.AddPerformer(singer);
            stage.AddSong(song);

            var result = stage.AddSongToPerformer("Song", "Ivan Ivanov");
            

            Assert.AreEqual(1, singer.SongList.Count);
            Assert.AreEqual($"{song} will be performed by {singer}", result);
        }

        [Test]
        public void PlayWorkCorrect()
        {
            Performer singer1 = new Performer("Ivan", "Ivanov", 21);
           
            Song song1 = new Song("Song", new TimeSpan(0, 2, 30));
            Song song2 = new Song("ACDC", new TimeSpan(0, 3, 30));
            Stage stage = new Stage();
            stage.AddPerformer(singer1);
          
            stage.AddSong(song1);
            stage.AddSong(song2);
            stage.AddSongToPerformer("Song", "Ivan Ivanov");
            stage.AddSongToPerformer("ACDC", "Ivan Ivanov");

            var result = stage.Play();


            Assert.AreEqual("1 performers played 2 songs", result);
        }
    }
}