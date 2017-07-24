using PeterSoft.SonarQube.Connector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Services
{
    public interface ISourcesScmService : IExecuteService<IList<Commit>>
    {

        /// <summary>
        /// each line individually. If ommitted by commit (optional)
        /// </summary>
        /// <param name="byLine"></param>
        /// <returns></returns>
        ISourcesScmService SetCommitsByLine(bool byLine);

        /// <summary>
        /// Set first line to retrieve
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        ISourcesScmService SetFromLine(int line);
        /// <summary>
        /// set last line to retrieve
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        ISourcesScmService SetToLine(int line);
        /// <summary>
        /// Set key of file to retrieve my_project:/src/foo/Bar.php
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        ISourcesScmService SetKey(string key);

    }
}
