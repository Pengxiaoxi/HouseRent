<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="myhouse.Web.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta name="keywords" content="�ٶȵ�ͼ,�ٶȵ�ͼAPI���ٶȵ�ͼ�Զ��幤�ߣ��ٶȵ�ͼ���������ù���" />
<meta name="description" content="�ٶȵ�ͼAPI�Զ����ͼ�������û��ڿ��ӻ����������ɰٶȵ�ͼ" />
<title>�ٶȵ�ͼAPI�Զ����ͼ</title>
<!--���ðٶȵ�ͼAPI-->
<style type="text/css">
    html,body{margin:0;padding:0;}
    .iw_poi_title {color:#CC5522;font-size:14px;font-weight:bold;overflow:hidden;padding-right:13px;white-space:nowrap}
    .iw_poi_content {font:12px arial,sans-serif;overflow:visible;padding-top:4px;white-space:-moz-pre-wrap;word-wrap:break-word}
</style>
<script type="text/javascript" src="http://api.map.baidu.com/api?key=&v=1.1&services=true"></script>
<script type="text/javascript" src="/MyAdmin/js/jquery-1.11.1.js"></script>

</head>

<body>
  <!--�ٶȵ�ͼ����-->
  <div style="width:800px;height:360px;border:#ccc solid 1px;" id="dituContent"></div>

 <div>
     <input type="hidden" id="houseadress" value="��ʯ�к�����ѧԺ"/>
     <input type="hidden" id="housecommunity" value="�ų�ɽ�ص��ѧ"/>
 </div>

</body>

<script type="text/javascript">
    //�����ͳ�ʼ����ͼ������
    function initMap(){
        createMap();//������ͼ
        setMapEvent();//���õ�ͼ�¼�
        addMapControl();//���ͼ��ӿؼ�
    }
    
    //=========
    // ������ַ������ʵ��
    var myGeo = new BMap.Geocoder();
    // ����ַ���������ʾ�ڵ�ͼ��,��������ͼ��Ұ
    myGeo.getPoint($("#houseadress").val(), function (point) {
        if (point) {
            map.centerAndZoom(point, 15);
            map.addOverlay(new BMap.Marker(point));

            var marker = new BMap.Marker(point);  // ������ע
            map.addOverlay(marker);              // ����ע��ӵ���ͼ��

            var label = new BMap.Label($("#housecommunity").val(), { offset: new BMap.Size(10, -50) });
            label.setStyle({  //���ֱ�ǩ��ʽ
                color: "white",
                background: "orangered",
                fontSize: "16px",
                height: "20px",
                lineHeight: "20px",
                fontFamily: "΢���ź�"
            });
            marker.setLabel(label);

            var circle = new BMap.Circle(point, 300, { strokeColor: "limegreen", strokeWeight: 1, strokeStyle: 'solid', fillColor: "limegreen", fillOpacity: 0.1 });  //���ø��������ɫ�߿�͸���ȵ�
            map.addOverlay(circle);            //����Բ
            hideOver();

        } else {
            //alert("��ѡ���ַû�н��������!");
            alert("��ַ�е�������ʱû�е�ͼ��Ϣ!");
        }
    }, "��ʯ��");
    //=========

    //������ͼ������
    function createMap(){
        var map = new BMap.Map("dituContent");//�ڰٶȵ�ͼ�����д���һ����ͼ
        var point = new BMap.Point(115.03,30.20);//����һ�����ĵ����꣨��ʯ��
        map.centerAndZoom(point,16);//�趨��ͼ�����ĵ�����겢����ͼ��ʾ�ڵ�ͼ������
        window.map = map;//��map�����洢��ȫ��  
    }
    
    //��ͼ�¼����ú�����
    function setMapEvent(){
        map.enableDragging();//���õ�ͼ��ק�¼���Ĭ������(�ɲ�д)
        map.enableScrollWheelZoom();//���õ�ͼ���ַŴ���С
        map.enableDoubleClickZoom();//�������˫���Ŵ�Ĭ������(�ɲ�д)
        map.enableKeyboard();//���ü����������Ҽ��ƶ���ͼ
    }
    
    //��ͼ�ؼ���Ӻ�����
    function addMapControl(){
        //���ͼ��������ſؼ�
	var ctrl_nav = new BMap.NavigationControl({anchor:BMAP_ANCHOR_TOP_LEFT,type:BMAP_NAVIGATION_CONTROL_SMALL});
	map.addControl(ctrl_nav);
        //���ͼ���������ͼ�ؼ�
	var ctrl_ove = new BMap.OverviewMapControl({anchor:BMAP_ANCHOR_BOTTOM_RIGHT,isOpen:0});
	map.addControl(ctrl_ove);
        //���ͼ����ӱ����߿ؼ�
	var ctrl_sca = new BMap.ScaleControl({anchor:BMAP_ANCHOR_BOTTOM_LEFT});
	map.addControl(ctrl_sca);
    }
    initMap();//�����ͳ�ʼ����ͼ
</script>
</html>
