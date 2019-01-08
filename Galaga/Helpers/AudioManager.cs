using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga.Helpers
{
    public class AudioManager
    {
        public SoundEffect shipFire;
        public SoundEffect shipHit;
        public SoundEffect enemyFire;
        public SoundEffect enemyHit;
        public SoundEffect explosion;

        public AudioManager(ContentManager theContent)
        {
            loadAudio(theContent);
        }

        private void loadAudio(ContentManager theContent)
        {
            shipFire = theContent.Load<SoundEffect>("Audio/shipFire");
            shipHit = theContent.Load<SoundEffect>("Audio/shipHit");
            enemyFire = theContent.Load<SoundEffect>("Audio/enemyFire");
            enemyHit = theContent.Load<SoundEffect>("Audio/enemyHit");
            explosion = theContent.Load<SoundEffect>("Audio/explosion");
        }
    }
}
