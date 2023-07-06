using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Vuforia
{
    public class targetData : MonoBehaviour
    {

        public Transform TextTargetName;
        public Transform TextDescription;
        public Transform ButtonAction;
        public Transform PanelDescription;

        public AudioSource soundTarget;
        public AudioClip clipTarget;

        // Use this for initialization
        void Start()
        {
		//add Audio Source as new game object component
            soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            StateManager sm = TrackerManager.Instance.GetStateManager();
            IEnumerable<TrackableBehaviour> tbs = sm.GetActiveTrackableBehaviours();

            foreach (TrackableBehaviour tb in tbs)
            {
                string name = tb.TrackableName;
                ImageTarget it = tb.Trackable as ImageTarget;
                Vector2 size = it.GetSize();

                Debug.Log("Active image target:" + name + "  -size: " + size.x + ", " + size.y);
			
//Evertime the target found it will show “name of target” on the TextTargetName. Button, Description and Panel will visible (active)

                // TextTargetName.GetComponent<Text>().text = name;
                ButtonAction.gameObject.SetActive(true);
                TextDescription.gameObject.SetActive(true);
                PanelDescription.gameObject.SetActive(true);


//If the target name was “zombie” then add listener to ButtonAction with location of the zombie sound (locate in Resources/sounds folder) and set text on TextDescription a description of the zombie

                if(name == "WhatsApp"){
                    TextTargetName.GetComponent<Text>().text = "Prodi TPL";
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("narasi"); });
                    TextDescription.GetComponent<Text>().text = "Program Studi Teknologi Rekayasa Perangkat Lunak atau disingkat TPL adalah program studi yang bertujuan untuk menghasilkan tenaga profesional sebagai Ahli Madya bidang Manajemen Informatika sesuai dengan kebutuhan dunia kerja.";
                }


//function to play sound
        void playSound(string ss){
            clipTarget = (AudioClip)Resources.Load(ss);
            soundTarget.clip = clipTarget;
            soundTarget.loop = false;
            soundTarget.playOnAwake = false;
            soundTarget.Play();
        }
    }
}}}