﻿using System.Collections.Generic;

namespace x2tap.Objects.v2rayConfig
{
	/// <summary>
	///		v2ray 配置
	/// </summary>
	public class v2rayConfig
	{
		/// <summary>
		///		日志
		/// </summary>
		public Log log = new Log();

		/// <summary>
		///		DNS
		/// </summary>
		public Dns dns = new Dns();

		/// <summary>
		///		路由
		/// </summary>
		public Routing routing = new Routing();

		/// <summary>
		///		入口
		/// </summary>
		public List<Inbound> inbounds = new List<Inbound>()
		{
			new Inbound()
			{
				port = 2810,
				listen = "127.0.0.1",
				protocol = "socks",
				settings = new Protocol.Inbound.Socks(),
				sniffing = new InboundSniffing(),
				tag = "defaultInbound"
			},
			new Inbound()
			{
				port = 53,
				listen = "127.0.0.1",
				protocol = "dokodemo-door",
				settings = new Protocol.Inbound.Dokodomo()
				{
					address = "1.1.1.1",
					network = "tcp,udp",
					port = 53
				},
				tag = "dnsInbound"
			}
		};

		/// <summary>
		///		出口
		/// </summary>
		public List<Outbound> outbounds = new List<Outbound>()
		{
			new Outbound()
			{
				sendThrough = Global.Config.AdapterAddress,
				protocol = "freedom",
				tag = "directOutbound"
			},
			new Outbound()
			{
				protocol = "dns",
				tag = "dnsOutbound"
			}
		};
	}
}
