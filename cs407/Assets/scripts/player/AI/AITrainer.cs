using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
using System;
using SharpNeat.Genomes.Neat;
using SharpNeat.EvolutionAlgorithms;
using log4net.Config;
using System.IO;
using Assets.scripts.AI;
using System.Xml;

public class AITrainer : MonoBehaviour
{

    static NeatEvolutionAlgorithm<NeatGenome> _ea;
    const string CHAMPION_FILE = @".\coevolution_champion.xml";

    // Use this for initialization
    void Start()
    {
        // Initialise log4net (log to console).
        XmlConfigurator.Configure(new FileInfo("log4net.properties"));

        // Experiment classes encapsulate much of the nuts and bolts of setting up a NEAT search.
        AIExperiment experiment = new AIExperiment(new AIFighterEvaluatorFactory());

        // Load config XML.
        XmlDocument xmlConfig = new XmlDocument();
        xmlConfig.Load("ai.config.xml");
        experiment.Initialize("AI", xmlConfig.DocumentElement);

        // Create evolution algorithm and attach update event.
        _ea = experiment.CreateEvolutionAlgorithm();
        _ea.UpdateEvent += new EventHandler(ea_UpdateEvent);

        // Start algorithm (it will run on a background thread).
        _ea.StartContinue();
    }

    static void ea_UpdateEvent(object sender, EventArgs e)
    {
        Debug.Log(string.Format("gen={0:N0} bestFitness={1:N6}", _ea.CurrentGeneration, _ea.Statistics._maxFitness));

        // Save the best genome to file
        var doc = NeatGenomeXmlIO.SaveComplete(new List<NeatGenome>() { _ea.CurrentChampGenome }, false);
        doc.Save(CHAMPION_FILE);
    }

    // Update is called once per frame
    void Update()
    {

    }
}