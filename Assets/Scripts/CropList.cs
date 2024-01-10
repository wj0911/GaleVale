using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropList : MonoBehaviour
{
    public static CropList Instance;
    public Crop potatoCommon, potatoUncommon, potatoRare, potatoEpic;
    public Crop yamCommon, yamUncommon, yamRare, yamEpic;
    public Crop carrotCommon, carrotUncommon, carrotRare, carrotEpic;
    public Crop beetCommon, beetUncommon, beetRare, beetEpic;
    public Crop onionCommon, onionUncommon, onionRare, onionEpic;

    private void Awake()
    {
        Instance = this;
    }

    public List<Crop> GetCrop(string crop) {
        List<Crop> crops;
        if (crop == "Potato") {
            crops = new List<Crop> {potatoCommon, potatoUncommon, potatoRare, potatoEpic};
        } else if (crop == "Yam") {
            crops = new List<Crop>  {yamCommon, yamUncommon, yamRare, yamEpic};
        } else if (crop == "Carrot") {
            crops = new List<Crop> {carrotCommon, carrotUncommon, carrotRare, carrotEpic};
        } else if (crop == "Beet") {
            crops = new List<Crop> {beetCommon, beetUncommon, beetRare, beetEpic};
        } else {
            crops = new List<Crop> {onionCommon, onionUncommon, onionRare, onionEpic};
        }
        return crops;
    }

    public List<Crop> GetCropList(string filter) {
        List<Crop> crops;
        if (filter == "upName") {
            crops = new List<Crop> {potatoCommon, potatoUncommon, potatoRare, potatoEpic, yamCommon, yamUncommon, yamRare, yamEpic, carrotCommon, carrotUncommon, carrotRare, carrotEpic, beetCommon, beetUncommon, beetRare, beetEpic, onionCommon, onionUncommon, onionRare, onionEpic};
        } else {
            crops = new List<Crop> {onionCommon, onionUncommon, onionRare, onionEpic, beetCommon, beetUncommon, beetRare, beetEpic, carrotCommon, carrotUncommon, carrotRare, carrotEpic, yamCommon, yamUncommon, yamRare, yamEpic, potatoCommon, potatoUncommon, potatoRare, potatoEpic};
        }
        return crops;
    }
}
