// 1. Cambiar el namespace
namespace InvisibleValuables
{
    // Atributos de BepInEx
    [BepInPlugin(
        "com.Gambrinus.InvisibleValuables",  // 2. Cambiar el ID del plugin
        "InvisibleValuables",                // 3. Cambiar el nombre público del mod
        "1.0.0"                              // Versión del mod
    )]
    
    // 4. Cambiar el nombre de la clase
    public class InvisibleValuablesPlugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // El mensaje del logger también se puede actualizar para que coincida
            Logger.LogInfo("Mod InvisibleValuables cargado y activo!");
            StartCoroutine(HideItemsCoroutine());
        }

        private IEnumerator HideItemsCoroutine()
        {
            while (true)
            {
                var allItems = FindObjectsOfType<ValuableObject>();

                foreach (var item in allItems)
                {
                    MeshRenderer renderer = item.gameObject.GetComponentInChildren<MeshRenderer>();

                    if (renderer != null && renderer.enabled)
                    {
                        renderer.enabled = false;
                    }
                }

                yield return new WaitForSeconds(5.0f);
            }
        }
    }
}
