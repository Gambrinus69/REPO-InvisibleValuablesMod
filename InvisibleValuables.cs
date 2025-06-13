// Directivas 'using' explícitas para asegurar que las librerías se reconocen.
using BepInEx;
using BepInEx.Logging;
using UnityEngine;
using System.Collections;

// El namespace de tu mod.
namespace InvisibleValuables
{
    // El atributo principal que define tu mod para BepInEx.
    [BepInPlugin(
        "com.Gambrinus.InvisibleValuables",  // ID único del plugin (GUID)
        "InvisibleValuables",                // Nombre del Mod
        "1.0.2"                              // Versión del Mod
    )]
    
    // La clase principal de tu plugin, que hereda de BaseUnityPlugin.
    public class InvisibleValuablesPlugin : BaseUnityPlugin
    {
        // Awake se llama una vez cuando el plugin es cargado por BepInEx.
        private void Awake()
        {
            // Escribe un mensaje en la consola de BepInEx para confirmar la carga.
            Logger.LogInfo("Mod InvisibleValuables loaded and is now active!");
            
            // Inicia la corrutina que se ejecutará en segundo plano.
            StartCoroutine(HideItemsCoroutine());
        }

        // Una Corrutina que se ejecuta periódicamente sin bloquear el juego.
        private IEnumerator HideItemsCoroutine()
        {
            // Un bucle infinito que se repetirá mientras el juego esté en ejecución.
            while (true)
            {
                // Busca todos los objetos en la escena que tengan el componente 'ValuableObject'.
                ValuableObject[] allItems = FindObjectsOfType<ValuableObject>();

                // Itera sobre cada uno de los objetos encontrados.
                foreach (ValuableObject item in allItems)
                {
                    // Busca el componente 'MeshRenderer' en el objeto o en cualquiera de sus hijos.
                    MeshRenderer renderer = item.GetComponentInChildren<MeshRenderer>();

                    // Si se encuentra un renderizador y está actualmente visible...
                    if (renderer != null && renderer.enabled)
                    {
                        // ...lo desactiva, haciéndolo invisible.
                        renderer.enabled = false;
                    }
                }

                // Pausa la ejecución de esta corrutina durante 5 segundos antes de volver a empezar el bucle.
                // Esto es mucho más eficiente que hacerlo en cada frame.
                yield return new WaitForSeconds(5.0f);
            }
        }
    }
}
