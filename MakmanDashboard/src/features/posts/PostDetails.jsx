import { styled } from 'styled-components';

const DetailHeader = styled.div`
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
  font-size: 1rem;
`;

const H6 = styled.h6`
  color: var(--grey-500);
  font-weight: 700;
`;

const P = styled.p`
  font-weight: 400;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
`;

const DetailsInfo = ({ label, value }) => {
  return (
    <DetailHeader>
      <H6>{label}</H6>
      <P title={value}>{value}</P>
    </DetailHeader>
  );
};

const PostContainer = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  overflow: hidden;
  padding: 0.5rem;
`;

export const PostDetails = ({ name, description, category }) => {
  return (
    <PostContainer>
      <DetailsInfo label='Name' value={name} />
      <DetailsInfo label='Description' value={description} />
      <DetailsInfo label='Category' value={category.name} />
    </PostContainer>
  );
};
