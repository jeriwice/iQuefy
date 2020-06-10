using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TestMe.DataModels;

namespace TestMe.Helpers
{
    class QuizHelpers
    {
        List<QuizQuestions> History;
        List<QuizQuestions> Geography;
        List<QuizQuestions> Space;
        List<QuizQuestions> Engineering;
        List<QuizQuestions> Programming;
        List<QuizQuestions> Business;

        public string GetTopicDescription(string topic)
        {
            string topicDescription = "";

            if (topic == "History")
            {
                topicDescription = "History is the study of the past as it is described in written documents. Events occurring before written record are considered prehistory. It is an umbrella term that relates to past events as well as the memory, discovery, collection, organization, presentation, and interpretation of information about these events.";
            }
            else if (topic == "Geography")
            {
                topicDescription = "Geography is the study of places and the relationships between people and their environments. Geographers explore both the physical properties of Earth's surface and the human societies spread across it.";
            }
            else if (topic == "Space")
            {
                topicDescription = "The concept of space is considered to be of fundamental importance to an understanding of the physical universe. However, disagreement continues between philosophers over whether it is itself an entity, a relationship between entities, or part of a conceptual framework.";
            }

            return topicDescription;
        }

        public List<QuizQuestions> GetQuizQuestions(string topic)
        {
            List<QuizQuestions> quizList = new List<QuizQuestions>();

            if (topic == "History")
            {
                InitializeHistory();
                quizList = History;
            }
            else if (topic == "Space")
            {
                InitializeSpace();
                quizList = Space;
            }
            else if (topic == "Geography")
            {
                InitializeGeography();
                quizList = Geography;
            }


            return quizList;    
        }

        void InitializeHistory()
        {
            History = new List<QuizQuestions>();
            History.Add(new QuizQuestions { QuizQuestion = "During which decade was slavery abolished in the United States?", QuizAnswer = "1860s", QuizOptionA = "1860s", QuizOptionB = "1840s", QuizOptionC = "1850s", QuizOptionD = "1870s" });
            History.Add(new QuizQuestions { QuizQuestion = "During which year did Christopher Columbus first arrive in the Americas?", QuizAnswer = "1495", QuizOptionA = "1495", QuizOptionB = "1492", QuizOptionC = "1498", QuizOptionD = "1501" });
            History.Add(new QuizQuestions { QuizQuestion = "Which year was the first edition of FIFA World Cup played", QuizAnswer = "1930", QuizOptionA = "1985", QuizOptionB = "1920", QuizOptionC = "1930", QuizOptionD = "2002" });
            History.Add(new QuizQuestions { QuizQuestion = "World War II also known as the Second World War, was a global war that lasted from 1939 to ?", QuizAnswer = "1945", QuizOptionA = "1986", QuizOptionB = "1922", QuizOptionC = "1945", QuizOptionD = "1939" });
            History.Add(new QuizQuestions { QuizQuestion = "The assassination of Julius Caesar was the result of a conspiracy by many Roman senators, he was stabbed by?", QuizAnswer = "Junius Brutus", QuizOptionA = "Obiesie Okarumee", QuizOptionB = "Cassius Longinus", QuizOptionC = "Junius Brutus", QuizOptionD = "Orsa Kemi" });
        }

        void InitializeGeography()
        {
            Geography = new List<QuizQuestions>();
            Geography.Add(new QuizQuestions { QuizQuestion = "What is the largest country in the world (by Area)?", QuizAnswer = "Russia", QuizOptionA = "Russia", QuizOptionB = "Canada", QuizOptionC = "United Sates", QuizOptionD = "China" });
            Geography.Add(new QuizQuestions { QuizQuestion = "Which of the following countries does NOT have a population exceeding 200 million?", QuizAnswer = "Nigeria", QuizOptionA = "Brazil", QuizOptionB = "Indonesia", QuizOptionC = "Pakistan", QuizOptionD = "Nigeria" });
            Geography.Add(new QuizQuestions { QuizQuestion = "Muscat is the capital of which country?", QuizAnswer = "Oman", QuizOptionA = "Oman", QuizOptionB = "Jordan", QuizOptionC = "Yemen", QuizOptionD = "Bahrain" });
            Geography.Add(new QuizQuestions { QuizQuestion = "Which is the world's smallest continent (by area)?", QuizAnswer = "Oceania", QuizOptionA = "Oceania", QuizOptionB = "Antractica", QuizOptionC = "South America", QuizOptionD = "Europe" });
            Geography.Add(new QuizQuestions { QuizQuestion = "Which of the following countries is NOT a member state of the European Union?", QuizAnswer = "Norway", QuizOptionA = "Finland", QuizOptionB = "Sweden", QuizOptionC = "Norway", QuizOptionD = "Denmark" });

        }

        void InitializeSpace()
        {
            Space = new List<QuizQuestions>();
            Space.Add(new QuizQuestions { QuizQuestion = "Who was the first man to ever walk on the Moon?", QuizAnswer = "Niel Armstrong", QuizOptionA = "Uchenna Nnodim", QuizOptionB = "Niel Armstrong", QuizOptionC = "Benjamin Franklin", QuizOptionD = "Pele Pele" });
            Space.Add(new QuizQuestions { QuizQuestion = "The coldest and farthest Planet from the Sun is ?", QuizAnswer = "Pluto", QuizOptionA = "Earth", QuizOptionB = "Pluto", QuizOptionC = "Neptune", QuizOptionD = "Saturn" });
            Space.Add(new QuizQuestions { QuizQuestion = "The galaxy that contains Solar System which Earth belongs to is called what?", QuizAnswer = "Milky Way", QuizOptionA = "Chocolate Path", QuizOptionB = "Phantom Zone", QuizOptionC = "Milky Way", QuizOptionD = "Solar Container" });
            Space.Add(new QuizQuestions { QuizQuestion = "How many days does it take the Earth to complete her orbit", QuizAnswer = "365 Days", QuizOptionA = "365 Days", QuizOptionB = "30 Days", QuizOptionC = "272 Days", QuizOptionD = "None of the Above" });
            Space.Add(new QuizQuestions { QuizQuestion = "An explosion which leads to gigantic explosion throwing star's outer layers are thrown out is called", QuizAnswer = "Supernova", QuizOptionA = "Black hole", QuizOptionB = "Double ring", QuizOptionC = "Massive Explosion", QuizOptionD = "Supernova" });

        }
    }
}