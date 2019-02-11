public interface IRopePartManager
{
	void InitRopePartDataOptions(RopeController ropeController, IRopePartDataOptions[] ropePartDatas);
	void SubscribeRopePartsOnUpdate(bool subscribe, IRopePartDataOptions[] ropePartDatas);
}
