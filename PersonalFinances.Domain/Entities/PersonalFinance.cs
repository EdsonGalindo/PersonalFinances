using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonalFinances.Domain.Entities
{
    public class PersonalFinance
    {
        private readonly List<Release> _releaseItems;
        public List<Release> ReleaseItems => _releaseItems;
        public int ReleaseAmount { get; private set; }

        public PersonalFinance()
        {
            _releaseItems = new List<Release>();
        }

        public PersonalFinance(Release release)
        {
            _releaseItems.Add(release);
            ReleaseAmount++;
        }

        public PersonalFinance(List<Release> releases)
        {
            _releaseItems = releases;
            ReleaseAmount += releases.Count;
        }

        public void AddRelease(Release release)
        {
            _releaseItems.Add(release);
            ReleaseAmount++;
        }

        public void AddReleaseList(List<Release> releases)
        {
            _releaseItems.AddRange(releases);
            ReleaseAmount += releases.Count;
        }

        public void RemoveRelease(Release release)
        {
            var releaseItem = ReleaseItems.FirstOrDefault(r => r.Account == release.Account && 
                            r.Date == release.Date && r.Description == release.Description && 
                            r.Type == release.Type && r.Value == release.Value);

            if (releaseItem == null)
                throw new Exception("Release was not localized!");

            _releaseItems.Remove(releaseItem);
            ReleaseAmount--;
        }
    }
}
