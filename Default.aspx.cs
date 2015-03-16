using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CDCase_ClassesDataContext cdcase = new CDCase_ClassesDataContext();
        cdcase.getdata();
        var linqQuery = cdcase.getdata();

        grd_Tracks.DataSource = linqQuery;
        grd_Tracks.DataBind();

    }
    protected void btn_getData_Clk(object sender, EventArgs e)
    {
        CDCase_ClassesDataContext cdcase = new CDCase_ClassesDataContext();
        grd_Tracks.DataSource = cdcase.Track_tbls;
        grd_Tracks.DataBind();
    }
    protected void btn_Insert_Clk(object sender, EventArgs e)
    {
        using(CDCase_ClassesDataContext cd = new CDCase_ClassesDataContext())
        {
            Track_tbl trk = new Track_tbl()
            {
                cd_id = 2,
                trk_id = 67,
                trk_length = 9,
                trk_num = 10,
                trk_title = "Melodies"
            };

            cd.Track_tbls.InsertOnSubmit(trk);
            cd.SubmitChanges();
        }
    }

    protected void btn_Update_Clk(object sender, EventArgs e)
    {
        using (CDCase_ClassesDataContext cd_case = new CDCase_ClassesDataContext())
        {
            Track_tbl trk = cd_case.Track_tbls.SingleOrDefault(x => x.trk_id == 11);
            trk.trk_length = 8.9;
            cd_case.SubmitChanges();
        }
    }

    protected void btn_Delete_Clk(object sender, EventArgs e)
    {
        using (CDCase_ClassesDataContext cd_case = new CDCase_ClassesDataContext())
        {
            Track_tbl trk = cd_case.Track_tbls.SingleOrDefault(x => x.trk_id == 11);
            cd_case.Track_tbls.DeleteOnSubmit(trk);
            cd_case.SubmitChanges();
        }
    }
}