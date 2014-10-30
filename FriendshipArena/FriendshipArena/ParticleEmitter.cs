using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FriendshipArena
{
    public class ParticleEmitter
    {
        public Vector2 position;
        public List<Particle> particles;
        public bool emit;

        private int numberOfParticles;

        public ParticleEmitter(Vector2 position) 
        {
            this.position = position;
            numberOfParticles = 5;
            particles = new List<Particle>();
            emit = false;

            for (int i = 0; i < numberOfParticles; i++) 
            {
                particles.Add(new Particle(this.position));
            }
        }

        public void Update(GameTime gameTime) 
        {
            for (int i = 0; i < numberOfParticles; i++)
            {
                //Particle 0 goes up and right
                particles[0].position.X += 1;
                particles[0].position.Y -= 1;

                //Particle 1 goes down and right
                particles[1].position.X += 1;
                particles[1].position.Y += 1;

                //Particle 2 goes down and left
                particles[2].position.X -= 1;
                particles[2].position.Y += 1;

                //Particle 3 goes up and left
                particles[3].position.X -= 1;
                particles[3].position.Y -= 1;
            }
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            for (int i = 0; i < numberOfParticles; i++)
            {
                particles[i].Draw(spriteBatch);
            }
        }
    }
}
